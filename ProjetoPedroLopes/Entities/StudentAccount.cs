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
        public double DailyWithdrawLimit { get; set; }

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
                Console.WriteLine("Saldo recusado, o valor solicitado excede o limite diário.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Saldo recusado, saldo insuficiente.");
            }
            else
            {
                Balance -= amount;
            }
        }
    }
}