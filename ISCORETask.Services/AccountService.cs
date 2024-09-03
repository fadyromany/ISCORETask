using ISCORETask.DAL;
using ISCORETask.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services
{
    public class AccountService : IAccountService
    {
        #region CTOR
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        #endregion

        public bool CheckUserExist(RegisterDto model)
        {
            return _accountRepository.UserExist(model.Email);
        }

        public void RegisterUser(RegisterDto model)
        {
            throw new NotImplementedException();
        }
    }
}
