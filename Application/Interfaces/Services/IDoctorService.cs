using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        BaseResponse CreateDoctor(CreateDoctorRequestModel request);
        DoctorResponseModel GetDoctorById(int id);
        DoctorResponseModel GetDoctorByDoctorNumber(string doctorNumber);
        BaseResponse UpdateDoctor(int id, UpdateDoctorRequestModel request);
        BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password);
        IList<DoctorResponseModel> GetDoctors();
        BaseResponse DeleteDoctor(int id);


    }
}
