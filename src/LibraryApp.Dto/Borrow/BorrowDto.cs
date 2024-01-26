namespace LibraryApp.Dto
{
    public class BorrowDto
    {
        public Guid? BookId { get; set; }
        public DateTime? ReturnDate {get;set;} = null;
        public string? Borrower {get;set;} = null;
    }
}