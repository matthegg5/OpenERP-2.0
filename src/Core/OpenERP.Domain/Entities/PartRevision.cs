using OpenERP.Domain.Common;

namespace OpenERP.Domain.Entities
{
    public class PartRevision : AuditableEntity
    {
        public Guid PartRevisionId { get; set; }
        public string PartNum { get; set; }
        public string RevisionNum { get; set; } = null!;
        public string PartRevDesc { get; set; } = null!;
        public bool Approved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedUser { get; set; } = null!;
        public string CompanyId { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
        public virtual Part Part { get; set; } = null!;
    }
}