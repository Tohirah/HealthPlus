using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;
        public ConsultationController (IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpPost]
        public IActionResult CreateNewConsultation([FromBody] CreateConsultationRequestModel request)
        {
            var response = _medicalRecordService.CreateConsultation(request);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpGet("appointmentId")]
        public IActionResult GetConsultationByAppointmentId([FromQuery] int appointmentId)
        {
            var response = _medicalRecordService.GetConsultationByAppointmentId(appointmentId);

            return response.Status ? Ok(response) : NotFound(response);
        }

        [HttpPut("{appointmentId}")]
        public IActionResult UpdateDiagnosis(int appointmentId, string diagnosis)
        {
            var response = _medicalRecordService.UpdateDiagnosis(appointmentId, diagnosis);

            return response.Status ? Ok(response) : BadRequest(response);
        }
    }
}
