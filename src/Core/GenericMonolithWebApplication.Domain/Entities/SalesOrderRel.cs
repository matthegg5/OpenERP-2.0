using GenericMonolithWebApplication.Domain.Common;

namespace GenericMonolithWebApplication.Domain.Entities
{
    public partial class SalesOrderRel : AuditableEntity
    {
        public string CompanyId { get; set; } = null!;
        public int SalesOrderNum { get; set; }
        public int SalesOrderLineNum { get; set; }
        public int SalesOrderRelNum { get; set; }
        public decimal ReleaseQty { get; set; }
        public DateTime? RequiredByDate { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual SalesOrderDtl SalesOrderDtl { get; set; } = null!;
    }
}
