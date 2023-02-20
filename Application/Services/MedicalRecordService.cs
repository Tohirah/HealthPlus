using HealthPlus.Application.DTOs;
using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Domain.Entities;

namespace HealthPlus.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IRepository _repository;

        public MedicalRecordService (IRepository repository)
        {
            _repository = repository;
        }

        public BaseResponse CreateConsultation(CreateConsultationRequestModel request)
        {
            var consultation = new Consultation
            {
                AppointmentId = request.AppointmentId,
                Complaint = request.Complaint,
                Diagnosis = request.Diagnosis,
                Temperature = request.Temperature,
                BloodPressure = request.BloodPressure,
                Weight = request.Weight,
                SugarLevel = request.SugarLevel,
                OxygenLevel = request.OxygenLevel
            };

            _repository.Add<Consultation>(consultation);
            _repository.SaveChanges();

            var appointment = _repository.Get<Appointment>(x => x.Id == request.AppointmentId);
            var record = AddConsultation(appointment.PatientId, request);

            return new BaseResponse
            {
                Message = "Consultation Record created successfully",
                Status = true
            };
        }

        public ConsultationResponseModel GetConsultationByAppointmentId(int appointmentId)
        {
            var consultation = _repository.GetConsultation(x => x.AppointmentId == appointmentId);

            if (consultation == null)
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
                Complaint = consultation.Complaint,
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
                Complaint = x.Complaint,
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
                Complaint = x.Complaint,
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

        public BaseResponse CreateMedicalRecord(int patientId)
        {
            var medicalRecord = new MedicalRecord
            {
                PatientId = patientId
            };
            _repository.Add<MedicalRecord>(medicalRecord);
            _repository.SaveChanges();

            return new BaseResponse
            {
                Message = "Medical Record created successfully",
                Status = true
            };
        }

        public MedicalRecordResponseModel GetMedicalRecordbyPatientId(int id)
        {
            var medicalRecord = _repository.Get<MedicalRecord>(x => x.Id == id);

            var ConsultationResponseModel = medicalRecord.Consultations.Select(x => new ConsultationResponseModel {
                AppointmentDate = x.Appointment.AppointmentDate,
                AppointmentId = x.AppointmentId,
                BloodPressure = x.BloodPressure,
                Temperature = x.Temperature,
                Weight = x.Weight,
                SugarLevel = x.SugarLevel,
                OxygenLevel = x.OxygenLevel,
                Complaint = x.Complaint,
                Diagnosis = x.Diagnosis,
                DoctorId = x.Appointment.DoctorId,
                Status = true
            }).ToList();

            return new MedicalRecordResponseModel
            {
                PatientId = medicalRecord.PatientId,
                Consultations = ConsultationResponseModel
            };
        }

        public BaseResponse AddConsultation(int patientId, CreateConsultationRequestModel request)
        {
            var medicalRecord = _repository.Get<MedicalRecord>(x => x.PatientId == patientId);

            var consultation = new Consultation
            {
                AppointmentId = request.AppointmentId,
                BloodPressure = request.BloodPressure,
                Temperature = request.Temperature,
                Weight = request.Weight,
                SugarLevel = request.SugarLevel,
                OxygenLevel = request.OxygenLevel,
                Diagnosis = request.Diagnosis,
                Complaint = request.Complaint
            };
            medicalRecord.Consultations.Add(consultation);

           var medicalRecordUpdate = _repository.Update(medicalRecord);
            _repository.SaveChanges();

            if (medicalRecordUpdate == null)
            {
                return new BaseResponse
                {
                    Message = "Record Update Not Succcessful",
                    Status = true
                };
            }

            return new BaseResponse
            {
                Message = "Record Updated successfully",
                Status = true
            };
        }
    }
}
