using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace LibraryApp.Domain
{
    public class Book : BaseEntity
    {
        public Book(Guid id, string authorName, string name, string? image) : base(id)
        {
            Name = name;
            AuthorName = authorName;
            Image = image;
        }
        public ICollection<Borrow>? Borrows {get;set;}
        public string Name { get; set; }
        public string? AuthorName {get;set;}
        public string? Image {get;set;}
    }
}