using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class PremiumAccount : Account
    {
        //percentual de cashback
        public double CashbackPercentage { get; set; }

        //Construtores
        public PremiumAccount() { }
        public PremiumAccount(int number, string holder, double balance, double cashbackPercentage)
            : base(number, holder, balance)
        {
            CashbackPercentage = cashbackPercentage;
        }

        //método saque sobrescrito
        public override void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Saque recusado: saldo insuficiente.");
            }
            else
            {
                Balance -= amount; // no fee
            }
        }

        //método para aplicar cashback
        public void ApplyCashback(double purchaseAmount)
        {
            double cashback = purchaseAmount * CashbackPercentage;
            Balance += cashback;
        }
    }
}
