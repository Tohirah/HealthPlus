using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;
using System.Numerics;

namespace HealthPlus.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository _doctorRepository;

        public DoctorService (IRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public BaseResponse CreateDoctor(CreateDoctorRequestModel request)
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
            _doctorRepository.Add<User>(user);

            var doctor = new Doctor
            {
                DoctorNumber = $"DR{Guid.NewGuid().ToString().Substring(4, 4).Replace("-", "")}",
                DepartmentId = request.DepartmentId,
                DateOfBirth= request.DateOfBirth,
                UserId = user.Id,
                User= user,
                ProfileImage = request.ProfileImage,
            };

            _doctorRepository.Add<Doctor>(doctor);
            _doctorRepository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profile Created Successfully",
                Status = true
            };
        }

        public DoctorResponseModel GetDoctorById(int id)
        {
            var doctor = _doctorRepository.GetDoctor(x => x.Id == id);

            if (doctor == null)
            {
                return new DoctorResponseModel
                {
                    Message = $"No record found for doctor with Id {id}",
                    Status = false
                };

            }
            return new DoctorResponseModel
            {
                Id = doctor.User.Id,
                FirstName = doctor.User.FirstName,
                DoctorNumber = doctor.DoctorNumber,
                DepartmentId= doctor.DepartmentId,
                LastName = doctor.User.LastName,
                Gender = doctor.User.Gender,
                Address = doctor.User.Address,
                DateOfBirth = doctor.DateOfBirth,
                Email = doctor.User.Email,
                PhoneNumber = doctor.User.PhoneNumber,
                ProfileImage = doctor.ProfileImage,
                Status = true
            };
        }

        public DoctorResponseModel GetDoctorByDoctorNumber (string doctorNumber)
        {
            var doctor = _doctorRepository.GetDoctor(x=> x.DoctorNumber == doctorNumber);
            if(doctor == null)
            {
                return new DoctorResponseModel
                {
                    Message = $"No Record found with Doctor Number {doctorNumber}",
                    Status = false
                };
            }

            return new DoctorResponseModel
            {
                DoctorNumber = doctor.DoctorNumber,
                DepartmentId = doctor.DepartmentId,
                FirstName = doctor.User.FirstName,
                LastName = doctor.User.LastName,
                Gender = doctor.User.Gender,
                Address = doctor.User.Address,
                DateOfBirth = doctor.DateOfBirth,
                Email = doctor.User.Email,
                PhoneNumber = doctor.User.PhoneNumber,
                ProfileImage = doctor.ProfileImage,
                Status = true
            };
        }

        public BaseResponse UpdateDoctor(int id, UpdateDoctorRequestModel request)
        {
            var doctor = _doctorRepository.GetDoctor(x => x.Id == id);

            doctor.User.PhoneNumber = request.PhoneNumber;
            doctor.User.Address = request.Address;

            var user = _doctorRepository.Update<User>(doctor.User);
            _doctorRepository.SaveChanges();

            if(user == null)
            {
                return new BaseResponse
                { 
                    Message = "Record Update Not Succcessful",
                    Status = true
                };
            }
            return new BaseResponse
            {
                Message = "Record Updated Succcessfully",
                Status = true
            };
        }

        public BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password)
        {
            var doctor = _doctorRepository.GetDoctor(x => x.Id == id);

            if (password.Password != null)
            {
                if (password.Password == password.ConfirmPassword)
                {
                    doctor.User.Password = password.Password;
                }
                else
                {
                    return new BaseResponse
                    {
                        Message = "Passwords do not match",
                        Status = false
                    };
                }
            }
            else
            {
                return new BaseResponse
                {
                    Message = "Password is empty. Enter Password",
                    Status = false
                };
            }

            var user = _doctorRepository.Update<Doctor>(doctor);
            _doctorRepository.SaveChanges();

            if(user == null)
            {
                return new BaseResponse
                {
                    Message = "Unable to update password",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Password updated successfully",
                Status = true
            };
        }


        public IList<DoctorResponseModel> GetDoctors()
        {
            var doctors = _doctorRepository.GetAllDoctors();


            var doctorResponse = doctors.Select(x => new DoctorResponseModel
            {
                Id = x.Id,
                UserId = x.UserId,
                DoctorNumber = x.DoctorNumber,
                DepartmentId= x.DepartmentId,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Gender = x.User.Gender,
                Address = x.User.Address,
                Email = x.User.Email,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber= x.User.PhoneNumber,
                ProfileImage = x.ProfileImage
            }).ToList();

            return doctorResponse;
        }

        public BaseResponse DeleteDoctor(int id)
        {
            var doctor = _doctorRepository.GetDoctor(x => x.Id == id);

            _doctorRepository.Delete<Doctor>(doctor);
            _doctorRepository.Delete<User>(doctor.User);

            _doctorRepository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profie deleted sucessfully",
                Status = true
            };
        }
    }
}
