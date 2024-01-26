using AutoMapper;
using LibraryApp.Domain;
using LibraryApp.Dto;
using LibraryApp.EntityFrameWorkCore;
using LibraryApp.Utils;

namespace LibraryApp.Manager
{
    public class BorrowManager : BaseManager, IBorrowManager
    {
        private readonly IRepository<Borrow> _borrowRepository;
        public BorrowManager(IGuidGenerator guidGenerator, IRepository<Borrow> borrowRepository, IMapper mapper) : base(guidGenerator, mapper)
        {
            _borrowRepository = borrowRepository;
        }
        public void Insert(BorrowDto borrowDto)
        {
            Validate(borrowDto);
            Borrow borrow = new(_guidGenerator.Create(), borrowDto.BookId!.Value, borrowDto.ReturnDate, borrowDto.Borrower);
            _borrowRepository.Insert(borrow);
        }

        private void Validate(BorrowDto borrowDto)
        {
            if(borrowDto.BookId.GetValueOrDefault(Guid.Empty) == Guid.Empty)
            {
                throw new Exception("Kitap seçilmesi zorunludur.");
            }
        }
    }
    public interface IBorrowManager
    {
        void Insert(BorrowDto borrowDto);
    }
}