using LibraryApp.Settings;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    public class BaseApiController : Controller
    {
        public BaseApiController()
        {
        }
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.BaseResult());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.BaseResult(result));
        }
        protected IActionResult BadRequest()
        {
            return base.BadRequest(Envelope.BaseError());
        }
        protected IActionResult BadRequest(string errorMessage)
        {
            return base.BadRequest(Envelope.BaseError(errorMessage));
        }
   }
}