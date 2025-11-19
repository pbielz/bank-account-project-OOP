using ProjetoPedroLopes.Entities.Enums;
using ProjetoPedroLopes.Exceptions;
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
        public double LoanLimit { get; private set; }
            
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
            double fee = 5.0; // taxa de saque
            double total = amount + fee;

            if (amount <= 0)
                throw new InvalidAmountException("Valor do saque deve ser positivo.");

            if (Balance < total)
                throw new InsufficientFundsException("Saldo insuficiente para realizar o saque com taxa.");

            Balance -= total;
        }

        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo: {AccountType.Business}, limite de empréstimo: {LoanLimit}";
        }
    }
}
