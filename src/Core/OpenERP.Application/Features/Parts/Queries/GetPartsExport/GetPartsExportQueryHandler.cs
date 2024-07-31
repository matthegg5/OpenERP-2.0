using System.Reflection.Metadata;
using AutoMapper;
using OpenERP.Application.Contracts.Infrastructure;
using OpenERP.Application.Contracts.Persistence;
using OpenERP.Domain.Entities;
using MediatR;

namespace OpenERP.Application.Features.Parts.Queries.GetPartsExport
{

    public class GetPartsExportQueryHandler : IRequestHandler<GetPartsExportQuery, PartExportFileVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Part> _partRepository;
        private readonly ICsvExporter _csvExport;

        public GetPartsExportQueryHandler(IMapper mapper, IAsyncRepository<Part> partRepository, ICsvExporter csvExport)
        {
            _mapper = mapper;
            _partRepository = partRepository;
            _csvExport = csvExport;
        }
        
        public async Task<PartExportFileVm> Handle(GetPartsExportQuery request, CancellationToken cancellationToken)
        {
            var allParts = _mapper.Map<List<PartExportDto>>((await _partRepository.ListAllAsync()).OrderBy(x => x.PartNum));

            var fileData = _csvExport.ExportPartsToCsv(allParts);

            var partExportFileDto = new PartExportFileVm() { ContentType = "text/csv", Data = fileData, PartExportFileName = $"{Guid.NewGuid}.csv" };

            return partExportFileDto;
        }
    }
}