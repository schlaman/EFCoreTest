namespace EFCoreTestDeploy.Data.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Console.WriteLine("ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)");
    }

    public DbSet<Vendor> Vendor { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Console.WriteLine("OnModelCreating() - Entry");
        Console.WriteLine("OnModelCreating() - Exit");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("OnConfiguring()");

        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
