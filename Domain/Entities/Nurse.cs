namespace HealthPlus.Domain.Entities
{
    public class Nurse : BaseEntity
    {
        public string NurseNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ProfileImage { get; set; }
    }
}
