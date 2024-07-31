#nullable disable

namespace OpenERP.Application.Features.Parts.Queries.GetPartsExport
{

    public class PartExportDto
    {
        public Guid PartId { get; set;}
        public string PartNum { get; set; }
        public string PartDescription { get; set;}
    }
}