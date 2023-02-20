using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository _repository;

        public PatientService(IRepository repository) 
        {
            _repository = repository;
        }
        public BaseResponse CreatePatient(CreatePatientRequestModel request)
        {
            var salt = Guid.NewGuid().ToString();
            var patientNumber = $"PA{Guid.NewGuid().ToString().Substring(0, 4).Replace("-", "")}";

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Address = request.Address,
                UserName = patientNumber,
                Salt = salt
            };
            user.Password =$"{request.Password} {salt}";

            _repository.Add<User>(user);

            var patient = new Patient
            {
                Allergies = request.Allergies,
                BloodGroup = request.BloodGroup,
                Genotype = request.Genotype,
                EmergencyContact = request.EmergencyContact,
                PatientNumber = patientNumber,
                DateOfBirth = request.DateOfBirth,
                UserId = user.Id,
                User = user,
            };

            _repository.Add<Patient>(patient);
            //_repository.Add<MedicalRecord>(patient.Id);

            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profile Successfully Created",
                Status = true
            };
        }

        public BaseResponse UpdatePatient(int id, UpdatePatientRequestModel request)
        {
            var patient = _repository.GetPatient(x => x.Id == id);
            patient.User.Email = request.Email;
            patient.User.PhoneNumber = request.PhoneNumber;
            patient.DateOfBirth = request.DateOfBirth;
            patient.Allergies = request.Allergies;
            patient.BloodGroup= request.BloodGroup;
            patient.Genotype = request.Genotype;
            patient.DateOfBirth = request.DateOfBirth;
            patient.EmergencyContact = request.EmergencyContact;

        

       
            var patientUpdate = _repository.Update<Patient>(patient);
            _repository.SaveChanges();
            if(patientUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Record Update Not Successful",
                    Status = false
                };
            }

            return new BaseResponse
            {
                Message = "Record Update Successfully",
                Status = true
            };

        }
        
        public BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password)
        {
            var patient = _repository.GetPatient(x => x.Id == id);
            if(password.Password != null)
            {
                if(password.Password == password.ConfirmPassword)
                {
                    patient.User.Password = password.Password;
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
            
            var patientUpdate = _repository.Update(patient);
            _repository.SaveChanges();

            if(patientUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Unable to update password",
                    Status = false
                };
            }
            return new BaseResponse
            {
                Message = "Password changed succssfully",
                Status = true
            };            
        }
        

        public PatientResponseModel GetPatientById(int id)
        {

            var patient = _repository.GetPatient(x => x.Id == id);

            if(patient == null)
            {
                return new PatientResponseModel
                {
                    Message = $"No record flund with patient Id {id}",
                    Status = false
                };
            }
            return new PatientResponseModel
            {
                PatientNumber = patient.PatientNumber,
                FirstName = patient.User.FirstName,
                LastName = patient.User.LastName,
                Gender = patient.User.Gender,
                Address = patient.User.Address,
                Email = patient.User.Email,
                PhoneNumber = patient.User.PhoneNumber,
                Genotype = patient.Genotype,
                BloodGroup = patient.BloodGroup,
                DateOfBirth = patient.DateOfBirth,
                Allergies = patient.Allergies,
                EmergencyContact = patient.EmergencyContact

            };
        }

        public PatientResponseModel GetPatientByPatientNumber(string patientNumber)
        {

            var patient = _repository.GetPatient(x => x.PatientNumber == patientNumber);


            if (patient == null)
            {
                return new PatientResponseModel
                {
                    Message = $"No record flund with patient Id {patientNumber}",
                    Status = false
                };
            }
            return new PatientResponseModel
            {
                FirstName = patient.User.FirstName,
                LastName = patient.User.LastName,
                Gender = patient.User.Gender,
                Address = patient.User.Address,
                Email = patient.User.Email,
                PhoneNumber = patient.User.PhoneNumber,
                Genotype = patient.Genotype,
                BloodGroup = patient.BloodGroup,
                DateOfBirth = patient.DateOfBirth,
                Allergies = patient.Allergies,
                EmergencyContact = patient.EmergencyContact

            };
        }

        public IList<PatientResponseModel> GetPatients()
        {

            var patients = _repository.GetAllPatient();


            var patientResponse = patients.Select(x => new PatientResponseModel
            {
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Gender = x.User.Gender,
                Address = x.User.Address,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber,
                Allergies= x.Allergies,
                EmergencyContact = x.EmergencyContact,
                BloodGroup= x.BloodGroup,
                Genotype= x.Genotype
            }).ToList();

            return patientResponse;
        }
        
    }
}
