using HealthPlus.Domain.Enums;

namespace HealthPlus.Application.DTOs
{
    public class UpdateConsultationRequestModel
    {
        public string Temperature { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string OxygenLevel { get; set; }
        public string SUgarLevel { get; set; }
        public string Diagnosis { get; set; }
        public int AppointmentId { get; set; }
    }
}
