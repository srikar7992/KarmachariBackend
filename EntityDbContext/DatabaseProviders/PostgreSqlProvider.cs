using Microsoft.EntityFrameworkCore;

namespace EntityDbContext.DatabaseProviders;

public class PostgreSqlProvider : IDatabaseProvider
{
    public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}
