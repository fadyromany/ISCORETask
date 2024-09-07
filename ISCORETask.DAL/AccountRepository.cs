using ISCORETask.Core.Context;
using ISCORETask.DTOs.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DAL
{
    public class AccountRepository : IAccountRepository
    {
        #region CTOR
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ISCOREContext _context;

        public AccountRepository(ISCOREContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Methods
        public async Task <bool> UserExist(string email)
        {
           var existingUser= await _userManager.FindByEmailAsync(email);
           return existingUser==null ? false:true;
        }

        public async Task<(ErrorResponse, IdentityUser user)> Register(IdentityUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return (null, user);
            }
            else
            {
                var error = result.Errors.Select(x => new ErrorResponse() { Code = 400, Title = x.Description }).FirstOrDefault();
                return (error, null);
            }
        }

        public Task<(ErrorResponse, IdentityUser user)> Update(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<(ErrorResponse, IdentityUser user)> Delete(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<(ErrorResponse, IdentityUser user)> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, password, isPersistent: false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return (null, user); // No error, return the authenticated user
            }
            if (result.IsNotAllowed)
            {
                return (new ErrorResponse { Code=400,Title = "User is not allowed to sign in." }, null);
            }
            
                return (new ErrorResponse() { Code = 400, Title = "Invalid UserName Or Password" }, null);
        }
        #endregion

    }
}
