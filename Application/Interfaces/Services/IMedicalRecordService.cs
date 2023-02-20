using HealthPlus.Application.DTOs;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IMedicalRecordService
    {
        BaseResponse CreateConsultation(CreateConsultationRequestModel request);
        ConsultationResponseModel GetConsultationByAppointmentId(int appointmentId);
        IList<ConsultationResponseModel> GetConsultationByDate(DateTime appointmentDate);
        IList<ConsultationResponseModel> GetConsultationByPatientId(int patientId);
        BaseResponse UpdateDiagnosis(int appointmentId, string diagnosis);
        BaseResponse CreateMedicalRecord(int patientId);
        BaseResponse AddConsultation(int id, CreateConsultationRequestModel request);
        MedicalRecordResponseModel GetMedicalRecordbyPatientId(int id);
    }
}
