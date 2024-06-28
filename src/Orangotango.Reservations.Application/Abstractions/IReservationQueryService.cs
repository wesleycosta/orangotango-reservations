using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Results;

namespace Orangotango.Reservations.Application.Abstractions;

public interface IReservationQueryService 
{
    Task<Result> GetById(Guid id);
    Task<IEnumerable<ReservationFullResult>> Search(string searchValue);
}
