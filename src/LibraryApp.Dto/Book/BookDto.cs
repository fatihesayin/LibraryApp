namespace LibraryApp.Dto
{
    public class BookDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? AuthorName {get;set;}
        public string? Image {get;set;}
        public DateTime? ReturnDate {get;set;} = null;
        public string? Borrower {get;set;} = null;
    }
}