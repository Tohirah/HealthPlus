using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseService _nurseService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NurseController(INurseService nurseService, IWebHostEnvironment webHostEnvironment)
        {
            _nurseService = nurseService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("createNurse")]
        public IActionResult CreateNurse([FromForm] CreateNurseRequestModel request)
        {
            var forms = HttpContext.Request.Form;
            if(forms.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images"); ;
                foreach(var file in forms.Files)
                {
                    FileInfo info = new FileInfo(file.FileName);
                    string imageName = Guid.NewGuid().ToString() + info.Extension;
                    string path = Path.Combine(imageDirectory, imageName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    request.ProfileImage= imageName;

                }
            }
            var response = _nurseService.CreateNurse(request);
            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpGet("getNurseById/id")]
        public IActionResult GetNurseById([FromQuery] int id)
        {
            var response = _nurseService.GetNurseById(id);
            return response.Status? Ok(response): NotFound(response.Message);
        }

        [HttpGet("getNurseByNurseNumber/{nurseNumber}")]
        public IActionResult GetNurseByNurseNumber([FromRoute] string nurseNumber)
        {
            var response = _nurseService.GetNurseByNurseNumber(nurseNumber);
            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet("getNurses")]
        public IActionResult GetNurses()
        {
            var response = _nurseService.GetNurses();
            return (response != null) ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("deleteNurse/id")]
        public IActionResult DeleteNurse([FromRoute] int id)
        {
            var response = _nurseService.DeleteNurse(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
