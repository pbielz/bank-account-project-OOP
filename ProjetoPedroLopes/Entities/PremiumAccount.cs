using ProjetoPedroLopes.Entities.Enums;
using ProjetoPedroLopes.Exceptions;
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
        public double CashbackPercentage { get; private set; }

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
                throw new InsufficientFundsException("Saldo insuficiente.");
            }
                Balance -= amount; // sem taxa de saque
        }

        //método para aplicar cashback
        public void ApplyCashback(double purchaseAmount)
        {
            double cashback = purchaseAmount * CashbackPercentage;
            Balance += cashback;
        }

       
        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo da conta: {AccountType.Premium}";
        }
    }
}
