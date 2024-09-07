using ISCORETask.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services.Abstractions
{
    public interface IBookService
    {
        Task AddBook(BookDto model);
        Task UpdateBook(BookDto model);
        Task DeleteBook(BookDto model);
        Task BookDetails(int id);
    }
}
