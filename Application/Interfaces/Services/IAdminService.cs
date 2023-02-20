using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IAdminService
    {
        BaseResponse CreateAdmin(CreateAdminRequestModel request);
        BaseResponse UpdateAdmin(UpdateAdminRequestModel request);
        AdminResponseModel GetAdminById(int adminId);
        AdminResponseModel GetAdminByAdminNumber(string adminNUmber);
    }
}
