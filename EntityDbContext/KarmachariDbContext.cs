using DataEntityModels;
using EntityDbContext.DatabaseProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUlid;

namespace EntityDbContext;

public class KarmachariDbContext : DbContext
{
    private readonly IDatabaseProvider? _databaseProvider;

    public DbSet<User> Users { get; set; }

    public KarmachariDbContext(DbContextOptions<KarmachariDbContext> options, IConfiguration configuration)
         : base(options)
    {
        var dbProvider = configuration.GetSection("DatabaseProvider").Value;
        _ = Enum.TryParse(dbProvider, out DatabaseProviderType dbProviderType);
        switch (dbProviderType)
        {
            case DatabaseProviderType.SqlServer:
                _databaseProvider = new SqlServerProvider(configuration);
                break;
            case DatabaseProviderType.PostgreSQL:
                _databaseProvider = new PostgreSqlProvider(configuration);
                break;
            case DatabaseProviderType.MySQL:
                break;
            default:
                throw new ArgumentException("Invalid database provider.");
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            _databaseProvider?.Configure(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity mappings and relationships here
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UserId).HasDefaultValueSql(Ulid.NewUlid().ToString());
            entity.Property(e => e.ActionType).HasMaxLength(50).HasDefaultValue("Insert");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql(DateTime.Now.ToString());
            entity.Property(e => e.UpdatedOn).HasDefaultValueSql(DateTime.Now.ToString());
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.FirstName).HasMaxLength(25).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.UserName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Password).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Phone);
        });
    }
}
