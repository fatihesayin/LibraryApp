namespace LibraryApp.Dto
{
    public class ListBookDto
    {
        public int PageCount {get;set;}
        public int TotalCount {get;set;}
        public List<BookDto> Books {get;set;} = new List<BookDto>();
    }
}