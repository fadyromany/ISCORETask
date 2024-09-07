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
        Task UpdateBook(BookVM model);
        Task DeleteBook(BookVM model);
        Task BookDetails(int id);
    }
}
