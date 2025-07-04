using System.Data.Common;
using Evently.Modules.Events.Application.Abstractions;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure.Data;

internal sealed class DbConnectionFactor(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async Task<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
