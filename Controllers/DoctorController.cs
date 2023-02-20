using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DoctorController(IDoctorService doctorService, IWebHostEnvironment webHostEnvironment)
        {
            _doctorService = doctorService;
            _webHostEnvironment= webHostEnvironment;
        }
        [HttpPost("CreateDoctor")]
        public IActionResult CreateDoctor([FromForm] CreateDoctorRequestModel request)
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
            var response = _doctorService.CreateDoctor(request);
            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpGet("getDoctorById/id")]
        public IActionResult GetDoctorById([FromQuery] int id)
        {
            var response = _doctorService.GetDoctorById(id);
            return response.Status? Ok(response): NotFound(response.Message);
        }

        [HttpGet("getDoctorByDoctorNumber/{doctorNumber}")]
        public IActionResult GetDoctorByDoctorNumber([FromRoute] string doctorNumber)
        {
            var response = _doctorService.GetDoctorByDoctorNumber(doctorNumber);
            return response.Status ? Ok(response) : NotFound(response.Message);
        }

        [HttpGet("updateDoctor/{id}")]
        public IActionResult UpdateDoctor([FromRoute] int id)
        {
            var response = _doctorService.GetDoctorById(id);
            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("updateDoctor/{id}")]
        public IActionResult UpdateDoctor([FromRoute] int id, UpdateDoctorRequestModel request)
        {
            var response = _doctorService.UpdateDoctor(id, request);
            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("updatePassword/{id}")]
        public IActionResult UpdatePassword([FromRoute] int id, UpdatePasswordRequestModel password)
        {
            var response = _doctorService.UpdatePassword(id, password);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("getDoctors")]
        public IActionResult GetDoctors()
        {
            var response = _doctorService.GetDoctors();
            return (response != null) ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("deleteDoctor/id")]
        public IActionResult DeleteDoctor([FromRoute] int id)
        {
            var response = _doctorService.DeleteDoctor(id);
            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
