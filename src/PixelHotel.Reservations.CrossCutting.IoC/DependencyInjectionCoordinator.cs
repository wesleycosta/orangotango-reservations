using Microsoft.Extensions.DependencyInjection;
using PixelHotel.Infra.Extensions;
using PixelHotel.Reservations.Infra.Data;

namespace PixelHotel.Reservations.CrossCutting.IoC;

public static class DependencyInjectionCoordinator
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddInfraConfiguration();

        new DataModule().RegisterServices(services);

        return services;
    }
}
