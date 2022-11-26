using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Contexts
{
    public class VolvoContext : DbContext
    {
        public VolvoContext(DbContextOptions<VolvoContext> options) : base(options)
        {

            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Possiblyty use configuration
            // modelBuilder.ApplyConfiguration(new VehicleMap());
            // modelBuilder.ApplyConfiguration(new VehicleModelMap());


            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");
                entity.HasKey(p => p.Id);


                entity.HasOne(p => p.VehicleModels)
                 .WithMany(a => a.Vehicles)
                 .HasForeignKey(b => b.Id)
                 .OnDelete(DeleteBehavior.Restrict);


                entity.Property(p => p.VehicleDescription)
                 .HasMaxLength(150)
                 .IsRequired();


                entity.Property(p => p.VehicleCreatedDate)
                .HasDefaultValue(DateTime.Now);

            });

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


        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
