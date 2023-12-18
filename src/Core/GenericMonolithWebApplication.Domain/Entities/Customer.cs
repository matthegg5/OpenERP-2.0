using GenericMonolithWebApplication.Domain.Common;

namespace GenericMonolithWebApplication.Domain.Entities
{
    public partial class Customer : AuditableEntity
    {
        public Customer()
        {
            SalesOrderHeds = new HashSet<SalesOrderHed>();
        }

        public string CompanyId { get; set; } = null!;
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<SalesOrderHed> SalesOrderHeds { get; set; }
    }
}