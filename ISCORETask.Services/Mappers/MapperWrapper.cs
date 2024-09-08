using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services.Mappers
{
    public partial class MapperWrapper : Profile
    {
        public MapperWrapper()
        {
            MappingProfile();
        }
    }
}
