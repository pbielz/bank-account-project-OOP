using ProjetoPedroLopes.Exceptions;
using ProjetoPedroLopes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    abstract class Account : IDepositable, IWithdrawable, ITranferable
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        //Construtores
        public Account() { }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        //Método saque
        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new InsufficientFundsException("Saque recusado: O valor do saque deve ser positivo.");
            }
            Balance -= amount + 2;
        }

        //Método depósito
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Depósito recusado: O valor do depósito deve ser positivo.");
            }
            Balance += amount;
        }

        //Método transferência
        public void Transfer(Account target, double amount)
        {
            this.Withdraw(amount);
            target.Deposit(amount);
        }
    }
}
