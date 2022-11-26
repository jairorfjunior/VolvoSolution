using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class VehicleModelMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.VehicleModelDescription)
            .HasMaxLength(150)
                .IsRequired();


            builder.Property(p => p.VehicleModelCreatedDate).HasDefaultValue(DateTime.Now);



        }
    }
}
