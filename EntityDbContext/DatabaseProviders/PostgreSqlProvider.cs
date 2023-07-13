using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityDbContext.DatabaseProviders;

public class PostgreSqlProvider : IDatabaseProvider
{
    private protected readonly string connectionString;

    public PostgreSqlProvider(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("PostgreSQLDatabaseConnection") ?? "";
    }

    public void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}
