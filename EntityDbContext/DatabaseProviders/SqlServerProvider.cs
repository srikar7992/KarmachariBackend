using Microsoft.EntityFrameworkCore;

namespace EntityDbContext.DatabaseProviders;

public class SqlServerProvider : IDatabaseProvider
{
    public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
