using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.BusinessLayer
{
    internal class CurrentAccount
    {
        public int OverdraftLimit { get; internal set; }
        public decimal Balance { get; internal set; }
    }
}
