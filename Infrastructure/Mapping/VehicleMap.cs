using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.VehicleDescription)
            .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(p => p.VehicleModels)
               .WithMany(a => a.Vehicles)
               .HasForeignKey(b => b.Id)
               .OnDelete(DeleteBehavior.Restrict);


            builder.Property(p => p.VehicleCreatedDate).HasDefaultValue(DateTime.Now);



        }
    }
}
