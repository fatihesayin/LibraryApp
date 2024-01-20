using LibraryApp.Domain;
using LibraryApp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [ApiController]
    public class AuthorController : BaseApiController
    {
        private readonly IGuidGenerator _guidGenerator;
        public AuthorController(IGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }
        public async Task<IActionResult> GetList(string query)
        {
            if(query.Length < 3)
            {
                return Ok(new List<Author>());
            }
            return Ok();
        }
    }
}