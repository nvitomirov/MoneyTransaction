using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyTransaction.DataAccess.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public Guid AccountId { get; set; }
            
        public int AccountNumber { get; set; }
    }
}
