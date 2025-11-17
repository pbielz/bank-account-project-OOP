using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPedroLopes.Exceptions;

namespace ProjetoPedroLopes.Entities
{
    internal class CheckingAccount : Account
    {

        //taxa de saque
        public double WithdrawFee { get; private set; }
        //limite de cheque especial
        public double OverdraftLimit { get; private set; }

        public CheckingAccount() { }
        public CheckingAccount(int number, string holder, double balance, double withdrawFee, double overdraftLimit) : base(number, holder, balance)
        {
            WithdrawFee = withdrawFee;
            OverdraftLimit = overdraftLimit;
        }

        //método saque sobrescrito
        public override void Withdraw(double amount)
        {
            double total = amount + WithdrawFee;

            if (Balance + OverdraftLimit <= total)
            {
                throw new InsufficientFundsException("Saque recusado: saldo insuficiente, incluindo limite de cheque especial.");
            }

            Balance -= total;


        }
    }
}