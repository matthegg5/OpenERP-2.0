using GenericMonolithWebApplication.Domain.Common;

namespace GenericMonolithWebApplication.Domain.Entities
{
    public class Part : AuditableEntity
    {
        public string PartNum { get; set; } = null!;
        public string PartDescription { get; set; } = null!;
    }
}