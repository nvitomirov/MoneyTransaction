using System;
using System.Threading.Tasks;

namespace MoneyTransaction.Service.Repositories
{
    public interface DeleteRepository
    {
        Task<bool> Delete(Guid id);
    }
}
