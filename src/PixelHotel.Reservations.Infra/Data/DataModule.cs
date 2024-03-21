using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;
using PixelHotel.Reservations.Business.Guests.Abstractions;
using PixelHotel.Reservations.Infra.Data.Repositories;

namespace PixelHotel.Reservations.Infra.Data;

public class DataModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IGuestRepository, GuestRepository>();

        return services;
    }
}
