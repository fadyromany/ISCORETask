using ISCORETask.DTOs.Common;
using ISCORETask.DTOs.Request;
using ISCORETask.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services.Abstractions
{
    public interface IBookService
    {
        Task AddBook(BookDto model,string userId);
        Task <ErrorResponse> UpdateBook(int id,BookDto model);
        Task <ErrorResponse> DeleteBook(int Id, string userId);
        Task<BookDto> BookDetails(int id,string userId);
        Task<BooksResponse> GetBooksWithFilte(int? page, int?pagesize,string? sortBy,string?order,string?searchKey);
    }
}
