using Orangotango.Reservations.Application;
using Orangotango.Reservations.Domain;
using Orangotango.Reservations.Infra;
using System.Reflection;

namespace Orangotango.Reservations.Api;

public static class AssemblyRegistry
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(ApplicationModule).Assembly;
        yield return typeof(DomainModule).Assembly;
        yield return typeof(InfraModule).Assembly;
    }
}
