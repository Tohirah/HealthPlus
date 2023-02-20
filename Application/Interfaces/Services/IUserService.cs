using HealthPlus.Application.DTOs;
using System.Linq.Expressions;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IUserService
    {
        BaseResponse CreateRole(CreateRoleRequestModel request);
        RoleResponseModel GetRoleById(int id);
        IList<RoleResponseModel> GetRoles();
        RoleResponseModel GetRoleByName(string name);
        UserResponseModel GetUserById(int id);
        UserResponseModel GetUserByUsername(string name);
        BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password);
        IList<UserResponseModel> GetUsers();
        // UserResponseModel LogIn(string email, string password);
        BaseResponse Login(string email, string password);

    }
}
