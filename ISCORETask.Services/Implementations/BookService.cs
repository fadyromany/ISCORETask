using ISCORETask.DAL.Repository.Abstractions;
using ISCORETask.DTOs.Request;
using ISCORETask.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services.Implementations
{
    public class BookService : IBookService
    {
        #region CTOR
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        #endregion
        public async Task AddBook(BookDto model)
        {
            await _bookRepository.AddBook(new Objects.BookVM());
        }

        public Task BookDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(BookDto model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(BookDto model)
        {
            throw new NotImplementedException();
        }
    }
}
