using HealthPlus.Domain.Enum;

namespace HealthPlus.Application.DTOs
{
    public class PatientResponseModel : BaseResponse
    {
        public string PatientNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string Allergies { get; set; }
        public string EmergencyContact { get; set; }
    }
}
