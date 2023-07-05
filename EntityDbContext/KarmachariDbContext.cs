using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDbContext;

public class KarmachariDbContext : DbContext
{
    private readonly string _connectionString;
    private readonly IDatabaseProvider _databaseProvider;

    public KarmachariDbContext(DbContextOptions<KarmachariDbContext> options, IConfiguration configuration, IDatabaseProvider databaseProvider)
         : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _databaseProvider = databaseProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            _databaseProvider.Configure(optionsBuilder, _connectionString);
        }
    }
}
