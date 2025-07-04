using Evently.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Evently.Api.Extensions;

internal static class MigrationExtensions
{
    internal static async Task ApplyMigrationsAsync(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        await ApplyMigrationsAsync<EventsDbContext>(scope);
    }

    private static async Task ApplyMigrationsAsync<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        await using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        await context.Database.MigrateAsync();
    }
}
