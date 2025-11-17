using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class CheckingAccount : Account
    {

        //taxa de saque
        public double WithdrawFee { get; set; }
        //limite de cheque especial
        public double OverdraftLimit { get; set; }

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

            if (Balance + OverdraftLimit >= total)
            {
                Balance -= total;
            }
            else
            {
                Console.WriteLine("Saque recusado, saldo insufieciente.");
            }

        }
    }
}