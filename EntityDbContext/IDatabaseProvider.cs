using Microsoft.EntityFrameworkCore;

namespace EntityDbContext;

public interface IDatabaseProvider
{
    void Configure(DbContextOptionsBuilder optionsBuilder);
}
