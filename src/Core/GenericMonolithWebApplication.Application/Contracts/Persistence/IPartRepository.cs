using GenericMonolithWebApplication.Domain.Entities;

namespace GenericMonolithWebApplication.Application.Contracts.Persistence
{
    public interface IPartRepository : IAsyncRepository<Part>
    {
	Task<bool> IsPartNumUnique(string partnum);   
    }
}
