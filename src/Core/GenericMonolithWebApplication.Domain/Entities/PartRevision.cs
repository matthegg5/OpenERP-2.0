using GenericMonolithWebApplication.Domain.Common;

namespace GenericMonolithWebApplication.Domain.Entities
{
    public class PartRevision : AuditableEntity
    {
        public Guid PartRevisionId { get; set; }
        public Guid PartId { get; set; }
        public string RevisionNum { get; set; } = null!;
    }
}