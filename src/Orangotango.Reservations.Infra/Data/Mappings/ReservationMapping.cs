using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orangotango.Infra.Data;
using Orangotango.Reservations.Domain.Reservations.Entities;

namespace Orangotango.Reservations.Infra.Data.Mappings;

internal sealed class ReservationMapping : MappingBase, IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Value)
            .IsRequired()
            .HasPrecision(12, 2);

        //builder.OwnsOne(p => p.Guest,
        //    p =>
        //    {
        //        p.Property(c => c.Name)
        //            .IsRequired()
        //            .HasColumnName("GuestName");

        //        p.Property(c => c.Email)
        //               .IsRequired()
        //               .HasColumnName("GuestEmail");
        //    });

        builder.OwnsOne(p => p.Period, p =>
        {
            p.Property(c => c.CheckIn)
                .IsRequired()
                .HasColumnName("CheckIn");

            p.Property(c => c.CheckOut)
                .IsRequired()
                .HasColumnName("CheckOut");
        });

        builder.HasOne(p => p.Room)
            .WithMany(p => p.Reservations)
            .HasForeignKey(p => p.RoomId);
    }
}
