using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain
{
    public class Borrow : BaseEntity
    {
        public Borrow(Guid id, Guid bookId, DateTime? returnDate, string? borrower) : base(id)
        {
            BookId = bookId;
            if(returnDate != null)
                ReturnDate = new DateTime(returnDate.Value.Ticks).ToUniversalTime();
            Borrower = borrower;
        }
        public string? Borrower {get;set;}
        [ForeignKey("Book")]
        public Guid BookId {get;set;}
        public DateTime? ReturnDate {get;set;}
    }
}