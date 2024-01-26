using AutoMapper;
using LibraryApp.Domain;
using LibraryApp.Dto;
using LibraryApp.Manager;
using LibraryApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : BaseApiController
    {
        private readonly IBookManager _bookManager;
        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insert([FromQuery]int? currentPage, [FromQuery]int? pageSize, [FromQuery]string? query = null)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetPagedList(int? currentPage, int? pageSize, string? query = null)
        {
            var response = await _bookManager.GetPagedList(currentPage.GetValueOrDefault(1) - 1, pageSize.GetValueOrDefault(10), query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(BookDto input)
        {
            BookDto book = await _bookManager.Insert(input);
            return Ok(book);
        }
    }
}