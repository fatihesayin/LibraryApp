using AutoMapper;
using LibraryApp.Domain;
using LibraryApp.Dto;

namespace LibraryApp.Api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDto>().BeforeMap((source, dest) => {
                if(source.Borrows != null && source.Borrows.Count > 0)
                {
                    var borrow = source.Borrows.FirstOrDefault();
                    if(borrow != null)
                    {
                        dest.Borrower = borrow.Borrower;
                        dest.ReturnDate = borrow.ReturnDate;
                    }
                }
            });
        }
    }
}