using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalServiceController : ControllerBase
    {
        private readonly IHospitalServiceService _serviceService;

        public HospitalServiceController(IHospitalServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpPost]
        public IActionResult CreateService([FromBody] CreateHospitalServiceRequestModel request)
        {
            var response = _serviceService.CreateService(request);

            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
