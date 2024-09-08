using ISCORETask.DTOs.Common;
using ISCORETask.DTOs.Request;
using ISCORETask.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DAL.Repository.Abstractions
{
    public interface IBookRepository
    {
        Task AddBook(BookVM model);
        Task<ErrorResponse> UpdateBook(int id,BookVM model);
        Task<ErrorResponse> DeleteBook(int id, string userId);
        Task<BookVM> BookDetails(int id,string userId);
        Task<BooksListVM> GetBooksWithFilte(int? page, int? pagesize, string? sortBy, string? order, string? searchKey);

    }
}
