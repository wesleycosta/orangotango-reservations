using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Infra.Abstractions;
using Orangotango.Reservations.Domain.Reservations;
using Orangotango.Reservations.Domain.Rooms;
using Orangotango.Reservations.Infra.Data;
using Orangotango.Reservations.Infra.Data.Repositories;
using Orangotango.Rooms.Infra.Extensions;

namespace Orangotango.Reservations.Infra;

public class InfraModule : IModuleRegiterWithConfiguration
{
    public IServiceCollection RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IPublisherEvent, PublisherEvent>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();

        return services;
    }
}
