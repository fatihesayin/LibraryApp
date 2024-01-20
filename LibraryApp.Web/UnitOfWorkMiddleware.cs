using LibraryApp.CrossCutting;

namespace LibraryApp.Web
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkMiddleware(RequestDelegate next, IUnitOfWork unitOfWork)
        {
            _next = next;
            _unitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            await _unitOfWork.Commit();
        }
    }
}