namespace HealthPlus.Domain.Entities
{
    public class Admin :BaseEntity
    {
        public string AdminNumber { get; set; }
        public string DateOfBirth { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
