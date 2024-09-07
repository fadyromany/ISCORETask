using ISCORETask.API.Extensions.Filters;
using ISCORETask.DTOs.Request;
using ISCORETask.Services;
using ISCORETask.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCORETask.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class BooksController : ApiBaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IBookService _bookService;
        public BooksController(IConfiguration configuration, IBookService bookService)
        {
            _configuration = configuration;
            _bookService = bookService;
        }

        [Authorize]
        [AuthnticationFilter]
        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto model)
        {
            var x = UserId;
            await _bookService.AddBook(model);
            return Ok();
        }

    }
}
