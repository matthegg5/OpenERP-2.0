using System;
using System.Collections.Generic;
using OpenERP.Domain.Common;

namespace OpenERP.Domain.Entities
{
    public partial class Company : AuditableEntity
    {
        public Company()
        {
            Addresses = new HashSet<Address>();
            Customers = new HashSet<Customer>();
            PartRevisions = new HashSet<PartRevision>();
            Parts = new HashSet<Part>();
            PurchaseOrderDtls = new HashSet<PurchaseOrderDtl>();
            PurchaseOrderHeds = new HashSet<PurchaseOrderHed>();
            PurchaseOrderRels = new HashSet<PurchaseOrderRel>();
            SalesOrderDtls = new HashSet<SalesOrderDtl>();
            SalesOrderHeds = new HashSet<SalesOrderHed>();
            SalesOrderRels = new HashSet<SalesOrderRel>();
            Suppliers = new HashSet<Supplier>();
            Uoms = new HashSet<Uom>();
        }

        public string CompanyId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<PartRevision> PartRevisions { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<PurchaseOrderDtl> PurchaseOrderDtls { get; set; }
        public virtual ICollection<PurchaseOrderHed> PurchaseOrderHeds { get; set; }
        public virtual ICollection<PurchaseOrderRel> PurchaseOrderRels { get; set; }
        public virtual ICollection<SalesOrderDtl> SalesOrderDtls { get; set; }
        public virtual ICollection<SalesOrderHed> SalesOrderHeds { get; set; }
        public virtual ICollection<SalesOrderRel> SalesOrderRels { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<Uom> Uoms { get; set; }
    }
}
