using HealthPlus.Domain.Enums;

namespace HealthPlus.Domain.Entities
{
    public class Appointment :BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public decimal Cost { get; set; }
        public bool IsPaid { get; set; }
        public bool IsAssigned { get; set; }

    }
}