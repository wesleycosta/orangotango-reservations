using PixelHotel.Reservations.Business.Guests.Abstractions;
using PixelHotel.Reservations.Business.Guests.Aggregates;
using System.Linq.Expressions;

namespace PixelHotel.Reservations.Infra.Data.Repositories;

internal class GuestRepository : IGuestRepository
{
    public void Add(Guest entity) => throw new NotImplementedException();
    public Task<IEnumerable<TResult>> GetByExpression<TResult>(Expression<Func<Guest, bool>> filter, Expression<Func<Guest, TResult>> projection) => throw new NotImplementedException();
    public Task<Guest> GetById(Guid id) => throw new NotImplementedException();
    public Task Remove(Guid id) => throw new NotImplementedException();
    public void Update(Guest entity) => throw new NotImplementedException();
}
