using Orangotango.Api;
using Orangotango.Reservations.Api;
using Orangotango.Reservations.Infra.Data;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithDefaultServices()
    .WithServicesFromAssemblies(AssemblyRegistry.GetAssemblies())
    .WithDefaultAppConfig()
    .WithApplyMigrate<ReservationsContext>()
    .Create();

app.Run();
