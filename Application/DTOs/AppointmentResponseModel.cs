using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.DTOs
{
    public class AppointmentResponseModel : BaseResponse
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public int PatientId { get; set; }
        public string Patient { get; set; }
        public int DoctorId { get; set; }
        public string Doctor { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public decimal Cost { get; set; }
        public bool IsPaid { get; set; }
        public bool IsAssigned { get; set; }
    }
}
