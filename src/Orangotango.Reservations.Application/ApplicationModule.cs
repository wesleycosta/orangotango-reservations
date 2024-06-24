using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Events.Rooms.Category;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Consumers;
using Orangotango.Reservations.Application.Services;

namespace Orangotango.Reservations.Application;

public partial class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryEventProcessor, CategoryEventProcessor>();

        services.AddScoped<IConsumer<CategoryUpsertedEvent>, CategoryUpsertEventConsumer>();

        return services;
    }
}
