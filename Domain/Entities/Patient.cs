
namespace HealthPlus.Domain.Entities
{
    public class Patient : BaseEntity
    {

        public string PatientNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string Allergies { get; set; }
        public string EmergencyContact { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
