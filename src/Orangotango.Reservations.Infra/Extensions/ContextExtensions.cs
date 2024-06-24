using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orangotango.Infra.Options;
using Orangotango.Reservations.Infra.Data;

namespace Orangotango.Rooms.Infra.Extensions;

internal static class ContextExtensions
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(BaseDataOptions.DefaultConnection));
        services.AddDbContext<ReservationsContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }
}
