namespace HealthPlus.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Doctor> Doctor { get; set; } = new HashSet<Doctor>();

    }
}
