using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IHospitalServiceService
    {
        BaseResponse CreateService(CreateHospitalServiceRequestModel request);
        BaseResponse UpdateService(UpdateHospitalServiceRequestModel request);
    }
}
