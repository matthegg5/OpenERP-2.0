#nullable disable
namespace OpenERP.Application.ViewModels
{
    public class PartRevisionsViewModel
    {
        public Guid PartRevisionId { get; set; }
        public Guid PartId { get; set; }
        public PartsViewModel Part { get; set;} = default!;
        public string RevisionNum { get; set; }
    }
}