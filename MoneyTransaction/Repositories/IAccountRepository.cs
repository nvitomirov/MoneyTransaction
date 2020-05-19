using MoneyTransaction.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransaction.Service.Repositories
{
    public interface IAccountRepository : CreateReadUpdateRepository<Account>, DeleteRepository
    {
        
    }
}
