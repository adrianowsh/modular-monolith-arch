using System.Data.Common;

namespace Evently.Modules.Events.Application.Abstractions;

public interface IDbConnectionFactory
{
    Task<DbConnection> OpenConnectionAsync();
}
