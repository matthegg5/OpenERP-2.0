using CsvHelper;
using GenericMonolithWebApplication.Application.Contracts.Infrastructure;
using GenericMonolithWebApplication.Application.Features.Parts.Queries.GetPartsExport;

namespace GenericMonolithWebApplication.Infrastructure.FileExport;

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
