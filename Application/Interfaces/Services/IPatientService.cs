using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IPatientService
    {
        BaseResponse CreatePatient(CreatePatientRequestModel request);
        BaseResponse UpdatePatient(int id, UpdatePatientRequestModel request);
        BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password);
        public PatientResponseModel GetPatientById(int id);
        public PatientResponseModel GetPatientByPatientNumber(string patientNumber);
        public IList<PatientResponseModel> GetPatients();
    }
}
