using ProjetoPedroLopes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Services
{
    internal class BankService
    {
        private List<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account GetAccount(int number)
        {
            return accounts.FirstOrDefault(a => a.Number == number);
        }

        public void PrintStatement(Account account)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Número da conta: {account.Number}");
            Console.WriteLine($"Proprietário(a) da conta:   {account.Holder}");
            Console.WriteLine($"Saldo: {account.Balance:C}");
            Console.WriteLine("------------------------------");
        }
    }
}
