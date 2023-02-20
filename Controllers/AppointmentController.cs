using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Application.Services;
using HealthPlus.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("CreateAppointment")]
        public IActionResult BookAppointment([FromBody] CreateAppointmentRequestModel request)
        {
            var response = _appointmentService.BookAppointment(request);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpPut("approveAppointment/{id}")]
        public IActionResult ApproveAppointment([FromRoute] int id)
        {
            var response = _appointmentService.ApproveAppointment(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("rejectAppointment/{id}")]
        public IActionResult RejectAppointment([FromRoute] int id)
        {
            var response = _appointmentService.RejectAppointment(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpPut("cancelAppointment/{id}")]
        public IActionResult CancelAppointment([FromRoute] int id)
        {
            var response = _appointmentService.CancelAppointment(id);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpGet("getAppointmentById/id")]
        public IActionResult GetAppointmentById([FromQuery] int id)
        {
            var response = _appointmentService.GetAppointmentById(id);

            return (response != null) ? Ok(response) : NotFound(response);
        }

        [HttpPut("payForApointment/{id}")]
       public IActionResult PayForApointment([FromRoute] int id)
        {
            var response = _appointmentService.PayForAppointment(id);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpPut("assignAppointmentToDoctor/id")]
        public IActionResult AssignAppointmentToDoctor([FromQuery] int id, UpdateAppointmentRequestModel request)
        {
            var response = _appointmentService.AssignAppointmentToDoctor(id, request);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPut("fulfillAppointment/id")]
        public IActionResult FulfillAppointment([FromQuery] int id)
        {
            var response = _appointmentService.FulfillAppointment(id);

            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet("getAppointments")]
        public IActionResult GetAppointments()
        {
            var response = _appointmentService.GetAppointments();

            return (response != null) ? Ok(response) : BadRequest(response) ;
        }

        [HttpGet("getAppointmentByPatientId/{id}")]
        public IActionResult GetAppointmentByPatientId(int id)
        {
            var response = _appointmentService.GetAppointmentByPatientId(id);

            return (response != null) ? Ok(response) : BadRequest(response);
        }

        [HttpPut("updateAppointment/{id}")]
        public IActionResult UpdateAppointment([FromRoute] int id, UpdateAppointmentRequestModel request)
        {
            var response = _appointmentService.UpdateAppointment(id, request);

            return response.Status? Ok(response): BadRequest(response);
        }

    }
}
