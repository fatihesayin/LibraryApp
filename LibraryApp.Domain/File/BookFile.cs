
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain
{
    public class BookFile : BaseEntity
    {
        public BookFile(Guid id) : base(id)
        {
        }
        public Guid BookId {get;set;}
        [ForeignKey(nameof(File))]
        public Guid FileId {get;set;}
        public File? File {get;set;}
    }
}