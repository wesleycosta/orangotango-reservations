using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Services;

namespace Orangotango.Reservations.Application;

public partial class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        RegistrationConsumers.RegisterConsumers(services);
        services.AddScoped<ICategoryEventProcessor, CategoryEventProcessor>();
        services.AddScoped<IRoomEventProcessor, RoomEventProcessor>();

        return services;
    }
}
