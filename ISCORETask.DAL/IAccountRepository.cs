using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.DAL
{
    public interface IAccountRepository
    {
        bool UserExist(string email);
    }
}
