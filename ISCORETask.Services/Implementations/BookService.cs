using AutoMapper;
using ISCORETask.DAL.Repository.Abstractions;
using ISCORETask.DTOs.Common;
using ISCORETask.DTOs.Request;
using ISCORETask.DTOs.Response;
using ISCORETask.Objects;
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
        private readonly IMapper _mapper;


        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        #endregion
        public async Task AddBook(BookDto model, string userId)
        {
            var obj = _mapper.Map<BookVM>(model);
            obj.UserId = userId;
            await _bookRepository.AddBook(obj);
        }

        public async Task<BookDto> BookDetails(int id, string userId)
        {
            var result = await _bookRepository.BookDetails(id, userId);
            return result == null ? null : _mapper.Map<BookDto>(result);

        }

        public async Task<ErrorResponse> DeleteBook(int id, string userId)
        {
            return await _bookRepository.DeleteBook(id, userId);
        }

        public async Task<BooksResponse> GetBooksWithFilte(int? page, int? pagesize, string? sortBy, string? order, string? searchKey)
        {
            var response=new BooksResponse();
            var result=await _bookRepository.GetBooksWithFilte(page, pagesize, sortBy, order, searchKey);
            var mapped=_mapper.Map<booksDTO>(result);
            response.Data=mapped;
            return response;


        }

        public async Task<ErrorResponse> UpdateBook(int id, BookDto model)
        {
            var entity = _mapper.Map<BookVM>(model);
            var result = await _bookRepository.UpdateBook(id, entity);
            return result == null ? null : result;
        }
    }
}
