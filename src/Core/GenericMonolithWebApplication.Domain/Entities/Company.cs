using GenericMonolithWebApplication.Domain.Common;

namespace GenericMonolithWebApplication.Domain.Entities
{
    public partial class Company : AuditableEntity
    {
        public Company()
        {
            Addresses = new HashSet<Address>();
            Customers = new HashSet<Customer>();
            Parts = new HashSet<Part>();
            SalesOrderDtls = new HashSet<SalesOrderDtl>();
            SalesOrderHeds = new HashSet<SalesOrderHed>();
            SalesOrderRels = new HashSet<SalesOrderRel>();
        }

        public string CompanyId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<SalesOrderDtl> SalesOrderDtls { get; set; }
        public virtual ICollection<SalesOrderHed> SalesOrderHeds { get; set; }
        public virtual ICollection<SalesOrderRel> SalesOrderRels { get; set; }
    }
}
