using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Infra.Abstractions;

namespace PixelHotel.Reservations.Infra;

public class InfraModule : IModuleRegiterWithConfiguration
{
    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
