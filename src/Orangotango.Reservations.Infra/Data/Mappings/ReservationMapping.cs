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

        builder.Property(p => p.GuestName)
            .IsRequired();

        builder.Property(p => p.GuestEmail)
            .IsRequired();

        builder.Property(p => p.Value)
            .IsRequired()
            .HasPrecision(12, 2);

        builder.HasOne(p => p.Room)
            .WithMany(p => p.Reservations)
            .HasForeignKey(p => p.RoomId);
    }
}
