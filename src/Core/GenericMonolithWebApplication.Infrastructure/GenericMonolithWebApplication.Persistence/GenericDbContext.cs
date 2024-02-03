using GenericMonolithWebApplication.Domain.Common;
using GenericMonolithWebApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericMonolithWebApplication.Infrastructure.Persistence;

public class GenericDbContext : DbContext
{
    public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options)
    {

    }
    public DbSet<Part> Parts { get; set;}
    public DbSet<PartRevision> PartRevisions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenericDbContext).Assembly);

        //seed data here
        var partGuid = new Guid();
        modelBuilder.Entity<Part>().HasData(new Part{
            PartId = partGuid,
            PartNum = "MATT-NEW-PART",
            PartDescription = "MATT-NEW-PART"
        });
        
        //base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
