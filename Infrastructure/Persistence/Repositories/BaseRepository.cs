using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Domain.Entities;
using HealthPlus.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace HealthPlus.Infrastructure.Perisstence.Repositories
{
    public class BaseRepository : IRepository
    {
        private readonly HealthPlusContext _context;

        public BaseRepository (HealthPlusContext context)
        {
            _context = context;
        }
        public T Add<T> (T entity) where T : class, new()
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
       
        public T Delete<T> (T entity) where T : class, new()
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
        public T Get<T> (Expression<Func<T, bool>> expression) where T : class, new()
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public IList<T> GetAll<T> (Expression<Func<T, bool>> expression = null) where T : class, new()
        {
            return _context.Set<T>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update<T> (T entity) where T : class, new()
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public Patient GetPatient(Expression<Func<Patient, bool>> expression)
        {
            return _context.Patients.Include(x => x.User).SingleOrDefault(expression);
        }

        public IList<Patient> GetAllPatient(Expression<Func<Patient, bool>> expression = null)
        {
            return _context.Patients.Include(x => x.User).ToList();
        }

        public Doctor GetDoctor(Expression<Func<Doctor, bool>> expresssion)
        {
            return _context.Doctors.Include(x => x.User).SingleOrDefault(expresssion);
        }

        public IList<Doctor> GetAllDoctors(Expression<Func<Doctor, bool>> expression = null)
        {
            return _context.Doctors.Include(x => x.User).ToList();
        }

        public MedicalRecord GetMedicalRecord(Expression<Func<MedicalRecord, bool>> expression)
        {
            return _context.MedicalRecords.SingleOrDefault(expression);
        }

        public IList<MedicalRecord> GetAllMedicalRecords(Expression<Func<MedicalRecord, bool>> expression = null)
        {
            return _context.MedicalRecords.ToList();

        }

        public Consultation GetConsultation(Expression<Func<Consultation, bool>> expression)
        {
            return _context.Consultations.Include(x => x.Appointment).SingleOrDefault(expression);
        }

        public IList<Consultation> GetAllConsultation(Expression<Func<Consultation, bool>> expression = null)
        {
            return _context.Consultations.Include(x => x.Appointment).ToList();
        }

        public Nurse GetNurse(Expression<Func<Nurse, bool>> expression)
        {
            return _context.Nurses.Include(x => x.User).SingleOrDefault(expression);
        }

        public IList<Nurse> GetAllNurses(Expression<Func<Nurse, bool>> expression = null)
        {
            return _context.Nurses.Include(x => x.User).ToList();
        }

        public Appointment GetAppointment(Expression<Func<Appointment, bool>> expression)
        {
            return _context.Appointments.Include(x => x.Doctor).ThenInclude(x => x.User).Include(x => x.Patient).ThenInclude(x => x.User).SingleOrDefault(expression);
        }

        public IList<Appointment> GetAllApppointment(Expression<Func<Appointment, bool>> expression = null)
        {
            return _context.Appointments.Include(x => x.Doctor).ThenInclude(x => x.User).Include(x => x.Patient).ThenInclude(x => x.User).ToList();

        }
    }
}
