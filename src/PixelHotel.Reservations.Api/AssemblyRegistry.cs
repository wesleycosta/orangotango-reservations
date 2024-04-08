using PixelHotel.Reservations.Application;
using PixelHotel.Reservations.Domain;
using PixelHotel.Reservations.Infra;
using System.Reflection;

namespace PixelHotel.Reservations.Api;

public static class AssemblyRegistry
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(ApplicationModule).Assembly;
        yield return typeof(DomainModule).Assembly;
        yield return typeof(InfraModule).Assembly;
    }
}
