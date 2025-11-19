using ProjetoPedroLopes.Entities.Enums;
using ProjetoPedroLopes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class StudentAccount : Account
    {
        //limite diário de saque
        public double DailyWithdrawLimit { get; private set; }

        //Construtores
        public StudentAccount() { }
        public StudentAccount(int number, string holder, double balance, double dailyWithdrawLimit)
            : base(number, holder, balance)
        {
            DailyWithdrawLimit = dailyWithdrawLimit;
        }

        //método saque sobrescrito
        public override void Withdraw(double amount)
        {
            if (amount > DailyWithdrawLimit)
            {
                throw new InvalidAmountException("Saque recusado: pedido de saque maior que o limite diário.");
            }
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Saque recusado: saldo insuficiente.");
            }
            Balance -= amount;
        }

        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo: {AccountType.Student}, limite diário: {DailyWithdrawLimit}";
        }
    }
}