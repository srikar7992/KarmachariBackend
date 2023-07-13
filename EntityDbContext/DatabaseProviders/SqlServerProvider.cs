using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityDbContext.DatabaseProviders;

public class SqlServerProvider : IDatabaseProvider
{
    private protected readonly string connectionString;

    public SqlServerProvider(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("SqlServerDatabaseConnection") ?? "";
    }

    public void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
