
using GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartsExport;

namespace GenericMonolithWebApplication.Application.Contracts.Infrastructure
{

    public interface ICsvExporter
    {
        byte[] ExportPartsToCsv(List<PartExportDto> partExportDtos);
    }
}