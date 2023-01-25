﻿using HealthPlus.Application.DTOs;
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

        [HttpPost]
        public IActionResult BookAppointment([FromBody] CreateAppointmentRequestModel request)
        {
            var response = _appointmentService.BookAppointment(request);

            return response.Status? Ok(response) : BadRequest(response);
        }

        [HttpPut("id")]
        public IActionResult ApproveAppointment([FromQuery] int id, AppointmentStatus appointmentStatus)
        {
            var response = _appointmentService.UpdateAppointmentStatus(id, appointmentStatus);

            return response.Status ? Ok(response) : BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentByid([FromQuery] int id)
        {
            var response = _appointmentService.GetAppointmentById(id);

            return (response != null) ? Ok(response) : NotFound(response);
        }
    }
}