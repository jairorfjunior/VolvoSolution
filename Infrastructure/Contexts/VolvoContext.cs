using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestModels.ConcurrencyModel;
using Microsoft.Extensions.Options;

namespace Infrastructure.Contexts
{
    public class VolvoContext : DbContext
    {
        public VolvoContext(DbContextOptions<VolvoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Possiblyty use configuration
            // modelBuilder.ApplyConfiguration(new VehicleMap());
            // modelBuilder.ApplyConfiguration(new VehicleModelMap());


            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("VehicleModel");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.VehicleModelDescription)
                .HasMaxLength(150)
                .IsRequired();

                entity.Property(p => p.VehicleModelCreatedDate)
                .HasDefaultValue(DateTime.Now);

                entity.HasData(new VehicleModel { Id = 1, VehicleModelDescription = "FH" },
                               new VehicleModel { Id = 2, VehicleModelDescription = "FM" });


            });


            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");
                entity.HasKey(p => p.Id);
 

                entity.Property(p => p.VehicleDescription)
                 .HasMaxLength(150)
                 .IsRequired();


                entity.Property(p => p.VehicleCreatedDate)
                .HasDefaultValue(DateTime.Now);


                entity.HasData(new Vehicle { Id = 1, IdVehicleModel = 1, VehicleDescription = "6x4", VehicleYearManufacture =  2022, VehicleYearModel = 2022 },
                             new Vehicle{ Id = 2, IdVehicleModel = 2, VehicleDescription = "4x2", VehicleYearManufacture = 2022, VehicleYearModel = 2022 });

            });



        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
