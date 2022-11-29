namespace Domain.Models
{
    public class VehicleModel : BaseEntity
    {
        public string VehicleModelDescription { get; set; }

        public DateTime VehicleModelCreatedDate { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
