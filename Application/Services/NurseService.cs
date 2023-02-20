using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class NurseService : INurseService
    {
        private readonly IRepository _repository;

        public NurseService (IRepository repository)
        {
            _repository = repository;
        }

        public BaseResponse CreateNurse(CreateNurseRequestModel request)
        {
        
            var salt = Guid.NewGuid().ToString();
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Gender = request.Gender,
                UserName = request.Email,
                Salt= salt
                
            };
            user.Password = $"{request.Password} {salt}";
            _repository.Add<User>(user);

            var nurse = new Nurse
            {
                NurseNumber = $"NR{Guid.NewGuid().ToString().Substring(4, 4).Replace("-", "")}",
                DepartmentId = request.DepartmentId,
                DateOfBirth= request.DateOfBirth,
                UserId = user.Id,
                User= user,
                ProfileImage = request.ProfileImage,
            };

            _repository.Add<User>(user);

            var nurse = new Nurse
            {
                NurseNumber = $"NR{Guid.NewGuid().ToString().Substring(0, 7)}",
                DateOfBirth = request.DateOfBirth,
                UserId = user.Id,
                User = user,
                ProfileImage = request.ProfileImage
            };

            user.Password = $"{request.Password} {salt}";
            _repository.Add<User>(user);

            var nurse = new Nurse
            {
                NurseNumber = $"DR{Guid.NewGuid().ToString().Substring(4, 4).Replace("-", "")}",
                DateOfBirth= request.DateOfBirth,
                UserId = user.Id,
                User= user,
                ProfileImage = request.ProfileImage,
            };

            _repository.Add<Nurse>(nurse);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = " Nurse Profile Created Successfully",
                Status = true
            };       
        }

        public NurseResponseModel GetNurseById(int id)
        {
            var nurse = _repository.GetNurse(x => x.Id == id);

            if (nurse == null)
            {
                return new NurseResponseModel
                {
                    Message = $"No record found for Nurse with Id {id}",
                    Status = false
                };
            }
            return new NurseResponseModel
            {
                FirstName = nurse.User.FirstName,
                NurseNumber = nurse.NurseNumber,
                LastName = nurse.User.LastName,
                Gender = nurse.User.Gender,
                Address = nurse.User.Address,
                DateOfBirth = nurse.DateOfBirth,
                Email = nurse.User.Email,
                PhoneNumber = nurse.User.PhoneNumber,
                ProfileImage = nurse.ProfileImage,
                Status = true
            };
        }


        public NurseResponseModel GetNurseByNurseNumber(string nurseNumber)
        {
            var nurse = _repository.GetNurse(x=> x.NurseNumber == nurseNumber);
            if(nurse == null)
            {
                return new NurseResponseModel
                {
                    Message = $"No Record found with Nurse Number {nurseNumber}",
                    Status = false
                };
            }

            return new NurseResponseModel
            {
                FirstName = nurse.User.FirstName,
                NurseNumber = nurse.NurseNumber,
                LastName = nurse.User.LastName,
                Gender = nurse.User.Gender,
                Address = nurse.User.Address,
                DateOfBirth = nurse.DateOfBirth,
                Email = nurse.User.Email,
                PhoneNumber = nurse.User.PhoneNumber,
                ProfileImage = nurse.ProfileImage,
                Status = true
            };
        }

        public IList<NurseResponseModel> GetNurses()
        {
             var nurses = _repository.GetAllNurses();


            var nurseResponse = nurses.Select(x => new NurseResponseModel
            {
                NurseNumber = x.NurseNumber,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Gender = x.User.Gender,
                Address = x.User.Address,
                Email = x.User.Email,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber= x.User.PhoneNumber,
                ProfileImage = x.ProfileImage
            }).ToList();

            return nurseResponse;
        }

        public BaseResponse UpdateNurse(UpdateNurseRequestModel request)
        {
            throw new NotImplementedException();
        }
        public BaseResponse DeleteNurse(int id)
        {
            var nurse = _repository.GetNurse(x => x.Id == id);

            _repository.Delete<Nurse>(nurse);
            _repository.Delete<User>(nurse.User);

            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profie deleted sucessfully",
                Status = true
            };
        }
    }
}
