using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class HospitalServiceService : IHospitalServiceService
    {
        private readonly IRepository _repository;

        public HospitalServiceService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateService(CreateHospitalServiceRequestModel request)
        {
            var service = new HospitalService
            {
                ServiceName = request.ServiceName,
                Price = request.Price,
            };

           _repository.Add(service);
           _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Service created successfully",
                Status = true
            };
        }

        public BaseResponse UpdateService(UpdateHospitalServiceRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
