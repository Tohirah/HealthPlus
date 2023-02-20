using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository _repository;

        public DepartmentService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateDepartment(CreateDepartmentRequestModel request)
        {
            var department = new Department
            {
                Name = request.Name,
                Description = request.Description,
            };

            _repository.Add<Department>(department);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Deapartment Created Successfully",
                Status = true
            };
        }

        public BaseResponse DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public DepartmentResponseModel GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateDepartment(UpdateDepartmentRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
