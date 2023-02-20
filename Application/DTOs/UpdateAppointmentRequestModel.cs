using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.DTOs
{
    public class UpdateAppointmentRequestModel
    {
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsPaid { get; set; }
    }
}
