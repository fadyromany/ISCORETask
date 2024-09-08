using ISCORETask.Core.Context;
using ISCORETask.DAL.Repository.Abstractions;
using ISCORETask.DTOs.Common;
using ISCORETask.DTOs.Request;
using ISCORETask.Objects;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddBook(BookVM entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            try
            {
                _context.Books.AddAsync(entity);
                await _context.SaveChangesAsync();
                var entryId = _context.Entry(entity).Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<BookVM> BookDetails(int id, string userId)
        {
            return await _context.Books.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ErrorResponse> DeleteBook(int id, string userId)
        {
            var book = await _context.Books.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();
            if (book == null)
                return (new ErrorResponse { Code = 404, Title = "Not Found!" });
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<BooksListVM> GetBooksWithFilte(int? page, int? pagesize, string? sortBy, string? order, string? searchKey)
        {
            // Apply default values if null
            var pageNumber = page ?? 1;
            var pageSizeValue = pagesize ?? 10;

            var query = _context.Books.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(b => b.Title.Contains(searchKey) || b.Author.Contains(searchKey));
            }

            // Ensure sortBy property is valid
            var orderByProperty = sortBy;
            query = order.ToLower() == "desc"
                ? query.OrderByDescending(b => EF.Property<object>(b, orderByProperty))
                : query.OrderBy(b => EF.Property<object>(b, orderByProperty));

            // Debug: Log the query and parameters
            Console.WriteLine($"Query: {query.ToQueryString()}");
            Console.WriteLine($"PageNumber: {pageNumber}, PageSize: {pageSizeValue}");

            // Count total items
            var totalItems = await query.CountAsync();

            // Fetch paginated results
            var skip = (pageNumber - 1) * pageSizeValue;
            var books = await query
                .Skip(skip)
                .Take(pageSizeValue)
                .ToListAsync();

            return new BooksListVM
            {
                TotalCount = totalItems,
                Page = pageNumber,
                PageSize = pageSizeValue,
                Books = books
            };


        }

        public async Task<ErrorResponse> UpdateBook(int id, BookVM entity)
        {

            if (id != entity.Id)
                return new ErrorResponse { Code = 400, Title = "Bad Request" };

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return new ErrorResponse { Code = 404, Title = "notfound.!" };

            // Update book 
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.PublicationDate = entity.PublicationDate;
            book.Quantity = entity.Quantity;
            book.ImageUrl = entity.ImageUrl;
            book.UpdatedDate = DateTime.UtcNow;

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;

        }
    }
}
