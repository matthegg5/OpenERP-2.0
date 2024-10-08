﻿using System;
using System.Collections.Generic;
using OpenERP.Domain.Common;

namespace OpenERP.Domain.Entities
{
    public partial class SalesOrderHed : AuditableEntity
    {
        public SalesOrderHed()
        {
            SalesOrderDtls = new HashSet<SalesOrderDtl>();
        }

        public string CompanyId { get; set; } = null!;
        public int SalesOrderNum { get; set; }
        public int CustomerId { get; set; }
        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        public DateTime? CustomerRequiredDate { get; set; }
        public DateTime? SuggestedShipDate { get; set; }
        public bool OpenOrder { get; set; }
        public bool CancelledOrder { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string CustomerPonum { get; set; } = null!;
        public string CreatedByUser { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }

        public virtual Customer C { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<SalesOrderDtl> SalesOrderDtls { get; set; }
    }
}
