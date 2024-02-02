#nullable disable
namespace GenericMonolithWebApplication.Application.ViewModels
{
    public class PartRevisionsViewModel
    {
        public Guid PartRevisionId { get; set; }
        public Guid PartId { get; set; }
        public PartsViewModel Part { get; set;} = default!;
        public string RevisionNum { get; set; }
    }
}