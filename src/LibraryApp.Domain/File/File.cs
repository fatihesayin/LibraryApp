
namespace LibraryApp.Domain
{
    public class File : BaseEntity
    {
        public File(Guid id) : base(id)
        {
        }
        public string? Path {get;set;}
    }
}