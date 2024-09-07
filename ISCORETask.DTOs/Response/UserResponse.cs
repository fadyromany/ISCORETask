using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DTOs.Response
{
    public class UserResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
