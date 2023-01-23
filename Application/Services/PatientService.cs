﻿using HealthPlus.Application.DTOs;
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

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Address = request.Address,
                UserName = request.Email,
                Salt = salt
            };
            user.Password =$"{request.Password} {salt}";

            _repository.Add(user);

            var patient = new Patient
            {
                Allergies = request.Allergies,
                BloodGroup = request.BloodGroup,
                Genotype = request.Genotype,
                EmergencyContact = request.EmergencyContact,
                PatientNumber = $"PA{Guid.NewGuid().ToString().Substring(0, 4).Replace("-", "")}",
                DateOfBirth = request.DateOfBirth,
                UserId = user.Id,
                User = user,
            };

            _repository.Add<Patient>(patient);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Profile Successfully Created",
                Status = true
            };
        }

        public BaseResponse UpdatePatient(UpdatePatientRequestModel request)
        {
            var patientModel = new Patient
            {
                Allergies = request.Allergies,
                BloodGroup = request.BloodGroup,
                Genotype = request.Genotype,
                EmergencyContact = request.EmergencyContact,
                DateOfBirth = request.DateOfBirth
            };

            var userModel = new User
            {
                FirstName= request.FirstName,
                LastName= request.LastName,
                Address = request.Address,
                Email = request.Email,
                PhoneNumber= request.PhoneNumber,
                Password= request.Password
            };
            var patient = _repository.Update<Patient>(patientModel);
            var user = _repository.Update<User>(userModel);
            _repository.SaveChanges();
            if(patientModel == null || userModel == null)
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
        

        public PatientResponseModel GetPatientById(int id)
        {

            var patient = _repository.Get<Patient>(x => x.Id == id);
            var user = _repository.Get<User>(x => x.Id == id);


            return new PatientResponseModel
            {
                PatientNumber = patient.PatientNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Genotype = patient.Genotype,
                BloodGroup = patient.BloodGroup,
                DateOfBirth = patient.DateOfBirth,
                Allergies = patient.Allergies,
                EmergencyContact = patient.EmergencyContact

            };
        }

        public PatientResponseModel GetPatientByPatientNumber(string patientNumber)
        {

            var patient = _repository.Get<Patient>(x => x.PatientNumber == patientNumber);
            var user = _repository.Get<User>(x => x.Id == patient.Id);


            return new PatientResponseModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.Password,
                Genotype = patient.Genotype,
                BloodGroup = patient.BloodGroup,
                DateOfBirth = patient.DateOfBirth,
                Allergies = patient.Allergies,
                EmergencyContact = patient.EmergencyContact

            };
        }

        // How to map responsemodel using both patient and user entities
        //public IList<PatientResponseModel> GetPatients()
        //{

        //    var patients = _repository.GetAll<Patient>();
        //    var users = _repository.GetAll<User>();


        //    var patientResponse = users.Select(x => new PatientResponseModel()
        //    {
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //        Gender = x.Gender,
        //        Address = x.Address,
        //        Email = x.Email,
        //        PhoneNumber = x.PhoneNumber,
        //        Password = x.Password
        //    }).ToList();

        //    return patientResponse;
        //}
    }
}
