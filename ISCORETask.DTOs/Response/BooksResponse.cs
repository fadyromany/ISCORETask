using ISCORETask.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DTOs.Response
{
    public class BooksResponse
    {
        public booksDTO Data { get; set; }

    }
    public class booksDTO
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<BookDto> books { get; set; }
    }
}
