using OpenERP.Application.Features.Parts.Queries.GetPartsExport;

namespace OpenERP.Application.Contracts.Infrastructure
{

    public interface ICsvExporter
    {
        byte[] ExportPartsToCsv(List<PartExportDto> partExportDtos);
    }
}