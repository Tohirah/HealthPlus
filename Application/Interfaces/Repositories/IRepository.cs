using HealthPlus.Domain.Entities;
using System.Linq.Expressions;

namespace HealthPlus.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : class, new();
        T Delete<T>(T entity) where T : class, new();
        T Update<T>(T entity) where T : class, new();
        T Get<T>(Expression<Func<T, bool>> expression) where T : class, new();
        IList<T> GetAll<T>(Expression<Func<T, bool>> expression = null) where T : class, new();
        Patient GetPatient(Expression<Func<Patient, bool>> expression);
        IList<Patient> GetAllPatient(Expression<Func<Patient, bool>> expression = null);
        Doctor GetDoctor(Expression<Func<Doctor, bool>> expression);
        IList<Doctor> GetAllDoctors(Expression<Func<Doctor, bool>> expression = null);
        MedicalRecord GetMedicalRecord(Expression<Func<MedicalRecord, bool>> expression);
        IList<MedicalRecord> GetAllMedicalRecords(Expression<Func<MedicalRecord, bool>> expression = null);
        Consultation GetConsultation(Expression<Func<Consultation, bool>> expression);
        IList<Consultation> GetAllConsultation(Expression<Func<Consultation, bool>> expression = null);
        Nurse GetNurse(Expression<Func<Nurse, bool>> expression);
        IList<Nurse> GetAllNurses(Expression<Func<Nurse, bool>> expression = null);
        Appointment GetAppointment(Expression<Func<Appointment, bool>> expression);
        IList<Appointment> GetAllApppointment(Expression<Func<Appointment, bool>> expression = null);



        int SaveChanges();
    }
}
