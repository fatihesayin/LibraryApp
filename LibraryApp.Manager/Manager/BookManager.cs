using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using LibraryApp.Domain;
using LibraryApp.Dto;
using LibraryApp.EntityFrameWorkCore;
using LibraryApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Manager
{
    public class BookManager : BaseManager, IBookManager
    {
        private readonly long MaxImageSize = 32000000;
        private readonly IRepository<Book> _bookRepository;
        private readonly IFileManager _fileManager;
        public BookManager(
            IRepository<Book> bookRepository, 
            IGuidGenerator guidGenerator, 
            IMapper mapper, 
            IFileManager fileManager) : base(guidGenerator, mapper)
        {
            _bookRepository = bookRepository;
            _fileManager = fileManager;
        }
        public async Task<ListBookDto> GetPagedList(int currentPage, int pageSize, string? query)
        {
            List<Book> books = new List<Book>();
            int totalCount = 0;
            if(string.IsNullOrWhiteSpace(query))
            {
                books = await _bookRepository.GetQueryable().Include(o => o.Borrows!.Where(bo => bo.ReturnDate > DateTime.UtcNow && bo.IsActive)).OrderBy(o => o.Name.ToLower()).Skip(pageSize * currentPage).Take(pageSize).ToListAsync();
                totalCount = await _bookRepository.GetQueryable().CountAsync();
            }
            else
            {
                books = await _bookRepository.GetQueryable().Include(o => o.Borrows!.Where(bo => bo.ReturnDate > DateTime.UtcNow && bo.IsActive)).Where(o => (o.Name.ToLower().Contains(query) || o.AuthorName!.ToLower().Contains(query)) && o.IsActive).OrderBy(o => o.Name.StartsWith(query)).OrderBy(o => o.Name.Contains(query)).Skip(pageSize * currentPage).Take(pageSize).ToListAsync();
                totalCount = await _bookRepository.GetQueryable().Where(o => o.Name.ToLower().Contains(query)).CountAsync();
            }
            foreach(var item in books)
            {
                if(string.IsNullOrWhiteSpace(item.Image))
                {
                    item.Image = await _fileManager.GetImage(Path.Combine("/",Directory.GetCurrentDirectory(), "files", "default.png"));
                } else {
                    item.Image = await _fileManager.GetImage(item.Image);
                }
            }
            return new ListBookDto{ Books = _mapper.Map<List<BookDto>>(books), TotalCount = totalCount, PageCount = (totalCount / pageSize) + 1};
        }

        public async Task<BookDto> Insert(BookDto bookDto)
        {
            Validate(bookDto);
            string? filePath = null;
            if(!string.IsNullOrEmpty(bookDto.Image))
            {
                filePath = await _fileManager.UploadImage(bookDto.Image);
            }
            Book book = new(_guidGenerator.Create(), bookDto.AuthorName!, bookDto.Name!, filePath);
            _bookRepository.Insert(book);
            return _mapper.Map<BookDto>(book);
        }
        private void Validate(BookDto book)
        {
            if(string.IsNullOrWhiteSpace(book.Name))
            {
                throw new Exception("Kitap ismi boş geçilemez");
            }
            if(string.IsNullOrWhiteSpace(book.AuthorName))
            {
                throw new Exception("Yazar boş geçilemez.");
            }
            if(book.Image != null && Convert.FromBase64String(book.Image).LongLength >= MaxImageSize)
            {
                throw new Exception("Maximum 32mb fotoğraf yükleyebilirsiniz.");
            }
        }
    }

    public interface IBookManager
    {
        Task<ListBookDto> GetPagedList(int currentPage, int pageSize, string? query);
        Task<BookDto> Insert(BookDto bookDto);
    }
}