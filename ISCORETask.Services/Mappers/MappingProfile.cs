using ISCORETask.DTOs.Request;
using ISCORETask.DTOs.Response;
using ISCORETask.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services.Mappers
{
    public partial class MapperWrapper
    {
        public void MappingProfile()
        {
            CreateMap<BookDto, BookVM>()
                .ForMember(o => o.ImageUrl, t => t.MapFrom(c => c.Image)).ReverseMap();
            CreateMap<booksDTO, BooksListVM>().ReverseMap();

        }
    }
}
