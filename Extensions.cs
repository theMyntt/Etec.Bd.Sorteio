using System;
using Etec.Sorteio.Context;
using Microsoft.EntityFrameworkCore;

namespace Etec.Sorteio;

public static class Extensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("msftSQL") ?? throw new Exception("msftSQL is null");

        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
            connectionString,
            m => m.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
        ));

        return services;
    }
}
