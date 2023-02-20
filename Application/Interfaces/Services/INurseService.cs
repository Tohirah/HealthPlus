using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface INurseService
    {
        BaseResponse CreateNurse(CreateNurseRequestModel request);
        IList<NurseResponseModel> GetNurses();
        NurseResponseModel GetNurseById(int id);
        NurseResponseModel GetNurseByNurseNumber(string nurseNumber);
        BaseResponse UpdateNurse(UpdateNurseRequestModel request);
        BaseResponse DeleteNurse(int id);
    }
}
