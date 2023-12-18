using GenericMonolithWebApplication.Domain.Common;

namespace GenericMonolithWebApplication.Domain.Entities
{
    public partial class Address : AuditableEntity
    {
        public string CompanyId { get; set; } = null!;
        public string ReferenceTable { get; set; } = null!;
        public int ForeignKeyId { get; set; }
        public int AddressId { get; set; }
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string Address3 { get; set; } = null!;
        public string City { get; set; } = null!;
        public int CountryNum { get; set; }
        public string PostCode { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
    }
}
