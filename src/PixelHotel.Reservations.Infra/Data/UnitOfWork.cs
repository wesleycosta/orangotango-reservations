using PixelHotel.Core.Abstractions;

namespace PixelHotel.Reservations.Infra.Data;

public sealed class UnitOfWork(ReservationsContext _context) : IUnitOfWork
{
    public async Task<bool> Commit()
        => await SaveChanges() > 0;

    public async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();
}
