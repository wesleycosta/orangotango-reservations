using Orangotango.Core.Abstractions;

namespace Orangotango.Reservations.Infra.Data;

public sealed class UnitOfWork(ReservationsContext _context) : IUnitOfWork
{
    public async Task<bool> Commit()
        => await _context.Commit();
}
