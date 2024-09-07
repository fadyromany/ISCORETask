using ISCORETask.DTOs.Common;
using ISCORETask.DTOs.Request;
using ISCORETask.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services
{
    public interface IAccountService
    {
        Task<bool> CheckUserExist(RegisterDto model);
        Task<(ErrorResponse,string?)> Register(RegisterDto model);
        Task<(ErrorResponse,UserResponse)> Login(LoginDto model);
    }
}
