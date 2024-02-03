#nullable disable
#pragma warning disable CS8603 
using GenericMonolithWebApplication.Application.Contracts.Persistence;
using GenericMonolithWebApplication.Domain.Entities;

namespace GenericMonolithWebApplication.Infrastructure.Persistence.Repositories
{
    public class PartRepository : BaseRepository<Part>, IPartRepository
    {
        public PartRepository(GenericDbContext dbContext) : base(dbContext)
        {
            
        }

        public Task<bool> IsPartNumUnique(string partnum)
        {
            var matches = _dbContext.Parts.Any(p => p.PartNum.Equals(partnum, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(matches);
        }
    }
}