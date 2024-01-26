using AutoMapper;
using LibraryApp.Domain;
using LibraryApp.Dto;
using LibraryApp.Manager;
using LibraryApp.Utils;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BorrowController : BaseApiController
    {
        private readonly IBorrowManager _borrowManager;
        public BorrowController(IBorrowManager borrowManager)
        {
            _borrowManager = borrowManager;
        }
        [HttpGet]
        public IActionResult Insert([FromQuery] Guid? bookId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(BorrowDto input)
        {
            _borrowManager.Insert(input);
            return Ok();
        }
    }
}