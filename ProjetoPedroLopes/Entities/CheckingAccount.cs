using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class CheckingAccount : Account
    {
        public double WithdrawFee { get; set; }
        public double OverdraftLimit { get; set; }

        public CheckingAccount() { }
        public CheckingAccount(int number, string holder, double balance, double withdrawFee, double overdraftLimit) : base( number, holder, balance)
        {
            WithdrawFee = withdrawFee;
            OverdraftLimit = overdraftLimit;
        }



    }
}
