using Microsoft.EntityFrameworkCore;
using MoneyTransaction.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyTransaction.Service.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

              

        public async Task<Account> InsertAsync(Account account)
        {
             _context.Add(account);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception )
            {
            
            }
            return account;
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Account>> GetAllAsync()
        {
            try
            {
                return await _context.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }


        public async Task<bool> UpdateAsync(Account account)
        {
            _context.Accounts.Attach(account);
            _context.Entry(account).State = EntityState.Modified;
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception )
            {
              
            }
            return false;
        }



        public async Task<bool> Delete(Guid id)
        {
            var accountDb = await _context.Accounts.SingleOrDefaultAsync(c => c.Id == id);
            _context.Remove(accountDb);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
            }
            return false;
        }

    
    }
}
