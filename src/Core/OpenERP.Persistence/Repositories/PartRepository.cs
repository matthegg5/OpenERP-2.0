#nullable disable
#pragma warning disable CS8603 
using OpenERP.Application.Contracts.Persistence;
using OpenERP.Domain.Entities;

namespace OpenERP.Infrastructure.Persistence.Repositories
{
    public class PartRepository : BaseRepository<Part>, IPartRepository
    {
        public PartRepository(OpenERPDbContext dbContext) : base(dbContext)
        {
            
        }

        public Task<bool> IsPartNumUnique(string partnum)
        {
            var matches = _dbContext.Parts.Any(p => p.PartNum.Equals(partnum, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(matches);
        }
    }
}