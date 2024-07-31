using OpenERP.Domain.Entities;

namespace OpenERP.Application.Contracts.Persistence
{
    public interface IPartRepository : IAsyncRepository<Part>
    {
	Task<bool> IsPartNumUnique(string partnum);   
    }
}
