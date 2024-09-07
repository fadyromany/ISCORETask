using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DTOs.Common
{
    public class ErrorResponse
    {
        public ErrorResponse(string title, int? code, object? data = null)
        {
            Title = title;
            Code = code ?? 400;
            Data = data;
        }
        public ErrorResponse()
        {

        }

        public string Title { get; set; }
        public int? Code { get; set; }
        public object? Data { get; set; }
    }
}
