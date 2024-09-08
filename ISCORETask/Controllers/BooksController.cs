using ISCORETask.API.Extensions.Filters;
using ISCORETask.DTOs.Request;
using ISCORETask.Services;
using ISCORETask.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

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
            await _bookService.AddBook(model, UserId);
            return Ok();
        }

        [Authorize]
        [AuthnticationFilter]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            var response = await _bookService.BookDetails(id, UserId);
            return response == null ? NoContent() : Ok(response);

        }
        [Authorize]
        [AuthnticationFilter]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var reponse = await _bookService.DeleteBook(id, UserId);
            return reponse == null ? Ok("Done Successfuly!") : NoContent();
        }

        [Authorize]
        [AuthnticationFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            var response = await _bookService.UpdateBook(id, bookDto);
            return response == null ? Ok("Updated Successfuly!") : NoContent();

        }
        [Authorize]
        [AuthnticationFilter]
        [HttpGet("GetListBooks")]
        public async Task<IActionResult> GetBooks(
          [FromQuery] int? page = 1,
          [FromQuery] int? pageSize = 10,
          [FromQuery] string? sortBy = "Title",
          [FromQuery] string? sortOrder = "asc",
          [FromQuery] string? search = "")
        {
            return Ok(await _bookService.GetBooksWithFilte(page, pageSize, sortBy, sortOrder, search));
        }
    }
}
