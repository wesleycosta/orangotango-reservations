using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Core.Abstractions;

namespace PixelHotel.Reservations.Domain;

public class DomainModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {

        return services;
    }
}
