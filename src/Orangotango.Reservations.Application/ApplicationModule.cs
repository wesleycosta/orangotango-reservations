﻿using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;
using Orangotango.Core.Extensions;
using Orangotango.Reservations.Application.Abstractions;
using Orangotango.Reservations.Application.Handlers;
using Orangotango.Reservations.Application.Services;
using Orangotango.Reservations.Domain.Reservations.Commands;

namespace Orangotango.Reservations.Application;

public partial class ApplicationModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        RegistrationConsumers.RegisterConsumers(services);
        services.AddScoped<IRoomEventProcessor, RoomEventProcessor>();
        services.AddScoped<ICategoryEventProcessor, CategoryEventProcessor>();

        services.AddScoped<IReservationMapper, ReservationMapper>();
        services.AddScoped<IReservationPublisher, ReservationPublisher>();
        services.AddScoped<IReservationQueryService, ReservationQueryService>();

        services.AddCommandHandler<ReservationCreateCommand, ReservationCreateCommandHandler>();
        services.AddCommandHandler<ReservationUpdateCommand, ReservationUpdateCommandHandler>();
        services.AddCommandHandler<ReservationRemoveCommand, ReservationRemoveCommandHandler>();

        return services;
    }
}
