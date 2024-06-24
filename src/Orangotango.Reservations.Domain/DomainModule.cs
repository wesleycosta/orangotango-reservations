using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;

namespace Orangotango.Reservations.Domain;

public class DomainModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {

        return services;
    }
}
