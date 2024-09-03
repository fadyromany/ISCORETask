using ISCORETask.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services
{
    public interface IAccountService
    {
        bool CheckUserExist(RegisterDto model);
        void RegisterUser(RegisterDto model);
    }
}
