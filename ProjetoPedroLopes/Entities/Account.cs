using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Entities
{
    internal class Account
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
            Balance -= amount + 5;
        }

        //Método depósito
        public void Deposit(double amount)
        {
            Balance += amount;
        }

    }
}
