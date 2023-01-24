﻿using HealthPlus.Application.DTOs;

namespace HealthPlus.Application.Interfaces.Services
{
    public interface IPatientService
    {
        BaseResponse CreatePatient(CreatePatientRequestModel request);
        BaseResponse UpdatePatient(int id, UpdatePatientRequestModel request);
        public PatientResponseModel GetPatientById(int id);
        public PatientResponseModel GetPatientByPatientNumber(string patientNumber);
        public IList<PatientResponseModel> GetPatients();
        //public PatientResponseModel LogIn(string email, string password);
    }
}
