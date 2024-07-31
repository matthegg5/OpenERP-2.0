using OpenERP.Domain.Common;

namespace OpenERP.Domain.Entities
{
    public class Part : AuditableEntity
    {
        public Part()
        {
            PartRevisions = new HashSet<PartRevision>();
            SalesOrderDtls = new HashSet<SalesOrderDtl>();
        }

        public string CompanyId { get; set; } = null!;

        public Guid PartId { get; set; }
        public string PartNum { get; set; } = null!;
        public string PartDescription { get; set; } = null!;
        public bool SerialTracked { get; set; }
        public string DefaultUom { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
        public virtual Uom Uom { get; set; } = null!;
        public virtual ICollection<PartRevision> PartRevisions { get; set; }
        public virtual ICollection<SalesOrderDtl> SalesOrderDtls { get; set; }
    }
}