namespace OpenERP.Application.Features.Parts.Queries.GetPartsExport
{
    
    public class PartExportFileVm
    {
        public string PartExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;

        public byte[]? Data { get; set; }
    }
}