using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Vehicle : BaseEntity
    {


        public int IdVehicleModel { get; set; }
        public string VehicleDescription { get; set; }

        public int VehicleYearManufacture { get; set; }

        public int VehicleYearModel { get; set; }

        public DateTime VehicleCreatedDate { get; set; }

        [JsonIgnore]
        public virtual VehicleModel? VehicleModels { get; set; }



    }
}
