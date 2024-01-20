using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain
{
    public class Borrow : BaseEntity
    {
        public Borrow(Guid id, Guid bookId, DateTime? returnDate) : base(id)
        {
            BookId = bookId;
            ReturnDate = returnDate;
        }

        [ForeignKey(nameof(Book))]
        public Guid BookId {get;set;}
        public Book? Book {get;set;}
        public DateTime? ReturnDate {get;set;}
    }
}