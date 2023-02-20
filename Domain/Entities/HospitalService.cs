namespace HealthPlus.Domain.Entities
{
    public class HospitalService : BaseEntity
    {
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
