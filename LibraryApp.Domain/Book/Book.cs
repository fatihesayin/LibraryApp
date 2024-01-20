using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace LibraryApp.Domain
{
    public class Book : BaseEntity
    {
        public Book(Guid id, Guid authorId, string name, byte[] image) : base(id)
        {
            Name = name;
            AuthorId = authorId;
            Image = image;
        }
        public string Name { get; set; }
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public Author? Author {get;set;}
        public byte[] Image {get;set;}
    }
}