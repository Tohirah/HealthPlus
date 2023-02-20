namespace HealthPlus.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string DoctorNumber { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ProfileImage { get; set; }
    }
}
