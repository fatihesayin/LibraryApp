
namespace LibraryApp.Domain
{
    public class Author : BaseEntity
    {
        public Author(Guid id, string name) : base(id)
        {
            Name = name;
        }
        public string Name {get;set;}
        public ICollection<Book>? Books {get;set;}
    }
}