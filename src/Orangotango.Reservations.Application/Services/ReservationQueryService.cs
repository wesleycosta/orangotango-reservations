using Orangotango.Core.Services;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Results;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Reservations.Entities;
using System.Linq.Expressions;

namespace Orangotango.Reservations.Application.Services;

internal sealed class ReservationQueryService(IReservationMapper _mapper,
    IReservationRepository _repository) : QueryServiceBase, IReservationQueryService
{
    public async Task<Result> GetById(Guid id)
    {
        var result = await GetReservationResultById(id);
        if (result is null)
            return NotFoundResult(nameof(Reservation));

        return SuccessfulResult(result);
    }

    public async Task<IEnumerable<ReservationFullResult>> Search(string searchValue)
    {
        Expression<Func<Reservation, bool>> filter = p => true;
        if (!string.IsNullOrEmpty(searchValue))
            filter = p => p.GuestName.Contains(searchValue) ||
             p.GuestEmail.Contains(searchValue) ||
             p.Room.Name.Contains(searchValue);

        return await _repository.GetByExpression(filter,
            p => _mapper.MapToFullResult(p),
            order => order.Room.Number,
            ascending: true,
            p => p.Room);
    }

    private async Task<ReservationResult> GetReservationResultById(Guid id)
        => await _repository.GetFirstByExpression(category => category.Id == id,
            p => _mapper.MapToResult(p));
}
