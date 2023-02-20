using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IRepository _repository;

        public ConsultationService(IRepository repository)
        {
            _repository = repository;
        }
        public BaseResponse CreateConsultation(CreateConsultationRequestModel request)
        {
            var consultation = new Consultation
            {
                AppointmentId = request.AppointmentId,
                Diagnosis = request.Diagnosis,
                Temperature = request.Temperature,
                BloodPressure = request.BloodPressure,
                Weight = request.Weight,
                SugarLevel = request.SugarLevel,
                OxygenLevel = request.OxygenLevel
            };

            _repository.Add<Consultation>(consultation);
            _repository.SaveChanges();
            return new BaseResponse
            {
                Message = "Consultation Record created successfully",
                Status = true
            };
        }

        public ConsultationResponseModel GetConsultationByAppointmentId(int appointmentId)
        {
            var consultation = _repository.GetConsultation(x => x.AppointmentId == appointmentId);

            if(consultation == null)
            {
                return new ConsultationResponseModel
                {
                    Message = $"No record found with Appointment Id {appointmentId}",
                    Status = false
                };
            }
            return new ConsultationResponseModel
            {
                AppointmentDate = consultation.Appointment.AppointmentDate,
                PatientId = consultation.Appointment.PatientId,
                DoctorId = consultation.Appointment.DoctorId,
                Diagnosis = consultation.Diagnosis,
                BloodPressure = consultation.BloodPressure,
                Temperature = consultation.Temperature,
                OxygenLevel = consultation.OxygenLevel,
                SugarLevel = consultation.SugarLevel,
                Status = true

            };
        }

        public IList<ConsultationResponseModel> GetConsultationByDate(DateTime appointmentDate)
        {
            var consultations = _repository.GetAllConsultation(x => x.Appointment.AppointmentDate == appointmentDate);


            var consultationResponse = consultations.Select(x => new ConsultationResponseModel
            {
                AppointmentDate = x.Appointment.AppointmentDate,
                PatientId = x.Appointment.PatientId,
                DoctorId = x.Appointment.DoctorId,
                Diagnosis = x.Diagnosis,
                BloodPressure = x.BloodPressure,
                Temperature = x.Temperature,
                OxygenLevel = x.OxygenLevel,
                SugarLevel = x.SugarLevel,
                Status = true

            }).ToList();
            return consultationResponse;
            
        }

        public IList<ConsultationResponseModel> GetConsultationByPatientId(int patientId)
        {
            var consultations = _repository.GetAllConsultation(x => x.Appointment.PatientId == patientId);

            var consultationsResponse = consultations.Select(x => new ConsultationResponseModel
            {
                AppointmentDate = x.Appointment.AppointmentDate,
                PatientId = x.Appointment.PatientId,
                DoctorId = x.Appointment.DoctorId,
                Diagnosis = x.Diagnosis,
                BloodPressure = x.BloodPressure,
                Temperature = x.Temperature,
                OxygenLevel = x.OxygenLevel,
                SugarLevel = x.SugarLevel,
                Status = true
            }).ToList();

            return consultationsResponse;
        }

        public BaseResponse UpdateDiagnosis(int appointmentId, string diagnosis)
        {
            var consultation = _repository.GetConsultation(x => x.AppointmentId == appointmentId);

            consultation.Diagnosis = diagnosis;
            _repository.Update(consultation);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Diagnosis updated successfully",
                Status = true
            };
        }
    }
}
