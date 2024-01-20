using LibraryApp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [ApiController]
    public class BookController : BaseApiController
    {
        private readonly IGuidGenerator _guidGenerator;
        public BookController(IGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }
        public async Task<IActionResult> GetPagedList(int currentPage, int pageSize, string query)
        {
            return Ok();
        }
        public async Task<IActionResult> Insert(int currentPage, int pageSize)
        {
            return Ok();
        }
    }
}