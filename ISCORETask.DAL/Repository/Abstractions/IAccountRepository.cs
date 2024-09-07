using ISCORETask.DTOs.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DAL.Repository.Abstractions
{
    public interface IAccountRepository
    {
        Task<bool> UserExist(string email);
        Task<(ErrorResponse, IdentityUser user)> Register(IdentityUser user, string password);
        Task<(ErrorResponse, IdentityUser user)> Update(IdentityUser user);
        Task<(ErrorResponse, IdentityUser user)> Delete(IdentityUser user);
        Task<(ErrorResponse, IdentityUser user)> Login(string email, string password);
    }
}
