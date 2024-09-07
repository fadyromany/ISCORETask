using ISCORETask.Core.Context;
using ISCORETask.DAL.Repository.Abstractions;
using ISCORETask.DTOs.Request;
using ISCORETask.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DAL.Repository.Implementations
{
    public class BookRepository : IBookRepository
    {
        #region CTOR
        private readonly ISCORETaskDbContext _context;

        public BookRepository(ISCORETaskDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task AddBook(BookVM model)
        {
            var book = new BookVM
            {
                Title = "bookDto.Title",
                UserId = "521cfa0e-0a38-4b3b-8d61-5ecb61d74aaf",
                Author = "bookDto.Author",
                Quantity = 100,
                ImageUrl = "",
                PublicationDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            try
            {
                var x = _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                var entry = _context.Entry(book);


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Task BookDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(BookVM model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(BookVM model)
        {
            throw new NotImplementedException();
        }
    }
}
