using CsvHelper;
using OpenERP.Application.Contracts.Infrastructure;
using OpenERP.Application.Features.Parts.Queries.GetPartsExport;

namespace OpenERP.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{

    public byte[] ExportPartsToCsv(List<PartExportDto> partExportDtos)
    {
        using var memorystream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memorystream))
        {
            using var csvWriter = new CsvWriter(streamWriter);
            csvWriter.WriteRecords(partExportDtos);
        }

        return memorystream.ToArray();
    }
}
