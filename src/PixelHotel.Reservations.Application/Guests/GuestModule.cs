using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Core.Services;
using PixelHotel.Reservations.Application.Guests.Handlers;
using PixelHotel.Reservations.Business.Guests.Commands;
using PixelHotel.Reservations.Business.Guests.Validations;

namespace PixelHotel.Reservations.Application.Guests;

public class GuestModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IValidator<GuestCreateCommand>, GuestCreateCommandValidation>();
        services.AddScoped<IRequestHandler<GuestCreateCommand, Result>, GuestCreateCommandHandler>();

        return services;
    }
}
