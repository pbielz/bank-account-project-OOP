using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class SavingAccount: Account
    {
        public double InterestRate { get; set; }

        public SavingAccount() { }

        public SavingAccount(int number, string holder, double balance, double iterestRate)
            : base(number, holder, balance)
        {
            InterestRate = iterestRate;
        }

        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

        public sealed override void Withdraw(double amount)
        {
            Balance -= amount;
        }
    }
}
