namespace Domain.Models
{
    public class Vehicle : BaseEntity
    {


        public int IdVehicleModel { get; set; }
        public string VehicleDescription { get; set; }

        public DateTime VehicleCreatedDate { get; set; }

        public virtual VehicleModel VehicleModels { get; set; }



    }
}
