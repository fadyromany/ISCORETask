using ISCORETask.Core.Context;
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
        private readonly ISCOREContext _context;

        public AccountRepository(ISCOREContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #endregion

        #region Methods
        public bool UserExist(string email)
        {
           var existingUser= _userManager.FindByEmailAsync(email);
           return existingUser!=null ? true:false;
        }
        #endregion

    }
}
