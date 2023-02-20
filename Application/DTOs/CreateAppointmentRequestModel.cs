using HealthPlus.Domain.Entities;
using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.DTOs
{
    public class CreateAppointmentRequestModel
    {
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
