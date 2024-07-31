using System;
using System.Collections.Generic;
using OpenERP.Domain.Common;

namespace OpenERP.Domain.Entities
{
    public partial class PurchaseOrderRel : AuditableEntity
    {
        public string CompanyId { get; set; } = null!;
        public int PurchaseOrderNum { get; set; }
        public int PurchaseOrderLineNum { get; set; }
        public int PurchaseOrderRelNum { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal OurOrderQty { get; set; }
        public decimal SupplierOrderQty { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public string LastChangeUser { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
    }
}
