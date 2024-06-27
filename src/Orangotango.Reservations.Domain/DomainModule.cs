using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Extensions;
using Orangotango.Reservations.Domain.Reservations.Commands;
using Orangotango.Rooms.Domain.Categories.Validations;

namespace Orangotango.Reservations.Domain;

public class DomainModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddValidator<ReservationCreateCommand, ReservationCreateCommandValidator>();
        services.AddValidator<ReservationUpdateCommand, ReservationUpdateCommandValidator>();
        services.AddValidator<ReservationRemoveCommand, ReservationRemoveCommandValidator>();

        return services;
    }
}
