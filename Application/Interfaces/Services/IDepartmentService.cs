using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        BaseResponse CreateDepartment(CreateDepartmentRequestModel request);
        BaseResponse UpdateDepartment(UpdateDepartmentRequestModel request);
        DepartmentResponseModel GetDepartmentById(int id);
        BaseResponse DeleteDepartment (int id);
    }
}
