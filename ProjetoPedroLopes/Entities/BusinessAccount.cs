using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class BusinessAccount :Account
    {
        //limite de empréstimo
        public double LoanLimit { get; set; }

        public BusinessAccount() { }

        public BusinessAccount(int number, string holder, double balance, double loanLimit)
            : base(number, holder, balance)
        {
            LoanLimit = loanLimit;
        }

        //método requisição empréstimo
        public void RequestLoan(double amount)
        {
            if (amount <= LoanLimit)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Empréstimo recusado, pedido acima do limite de empréstimo.");
            }
        }

        //método saque sobrescrito
        public override void Withdraw(double amount)
        {
            double fee = 5.0; // taxa fixa de saque para conta empresarial
            double total = amount + fee;

            if (Balance >= total)
            {
                Balance -= total;
            }
            else
            {
                Console.WriteLine("Saque recusado: saldo insuficiente.");
            }
        }
    }
}
