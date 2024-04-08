using PixelHotel.Api;
using PixelHotel.Reservations.Api;

var app = new WebAppBuilder()
    .BuildDefault(args)
    .WithDefaultServices()
    .WithServicesFromAssemblies(AssemblyRegistry.GetAssemblies())
    .WithDefaultAppConfig()
    .Create();

app.Run();
