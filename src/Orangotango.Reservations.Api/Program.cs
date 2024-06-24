using Orangotango.Api;
using Orangotango.Reservations.Api;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithDefaultServices()
    .WithServicesFromAssemblies(AssemblyRegistry.GetAssemblies())
    .WithDefaultAppConfig()
    .Create();

app.Run();
