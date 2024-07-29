#nullable disable
using GenericMonolithWebApplication.Domain.Common;
using GenericMonolithWebApplication.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace GenericMonolithWebApplication.Infrastructure.Persistence
{
    public class GenericDbContext : IdentityDbContext<IdentityUser>
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
            var partGuid = new Guid("31ae5210-236f-4e65-ac59-b6b16e204c9e");
            modelBuilder.Entity<Part>().HasData(new Part{
                PartId = partGuid,
                PartNum = "MATT-NEW-PART",
                PartDescription = "MATT-NEW-PART"
            });
            
            base.OnModelCreating(modelBuilder);
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
}
