using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.DTOs
{
    public class MedicalRecordResponseModel
    {
        public int PatientId { get; set; }
        public List<ConsultationResponseModel> Consultations { get; set; }
    }
}
