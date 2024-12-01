using System;
using Etec.Sorteio.Context;
using Etec.Sorteio.Controllers;
using Etec.Sorteio.Repositories;
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

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<MensagemRepository>();
        services.AddScoped<ParticipantesRepository>();
        services.AddScoped<PresenteRepository>();
        services.AddScoped<SorteioRepository>();

        return services;
    }

    public static IServiceCollection AddMvcControllers(this IServiceCollection services)
    {
        services.AddScoped<ParticipanteController>();
        services.AddScoped<SorteioController>();
        services.AddScoped<PresenteController>();

        return services;
    }
}
