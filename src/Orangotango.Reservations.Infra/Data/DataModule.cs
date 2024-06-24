using Microsoft.Extensions.DependencyInjection;
using Orangotango.Core.Abstractions;

namespace Orangotango.Reservations.Infra.Data;

public class DataModule : IModuleRegister
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        return services;
    }
}
