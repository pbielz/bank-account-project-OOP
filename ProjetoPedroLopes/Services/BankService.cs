using ProjetoPedroLopes.Entities;
using ProjetoPedroLopes.Entities.Enums;
using ProjetoPedroLopes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPedroLopes.Services
{
    internal class BankService
    {
        private readonly List<Account> accounts = new List<Account>();


        

        //1- Criar Conta
        public static void CreateAccount(BankService bank)
        {
            int number;
            Console.Write("Digite o número da conta: ");
            while (true)
            {
                number = int.Parse(Console.ReadLine());
                if (bank.GetAccount(number) != null)
                {
                    Console.Write("Número de conta já existente. Digite outro número: ");
                }
                else
                    break;
            }
            Console.Write("Digite o nome do proprietário da conta: ");
            string holder = Console.ReadLine();
            Console.Write("Digite o saldo inicial: ");
            double balance = double.Parse(Console.ReadLine());
            if (balance <= 0)
            {
                throw new InsufficientFundsException("Dinheiro insuficiente");
            }
            Console.WriteLine("Escolha o tipo da conta que deseja criar: ");
            Console.WriteLine("1. Conta Corrente");
            Console.WriteLine("2. Conta Empresarial");
            Console.WriteLine("3. Conta Estudantil");
            Console.WriteLine("4. Conta Premium");
            int type = int.Parse(Console.ReadLine());
            AccountType accountType = (AccountType)type;

            switch (accountType)
            {
                case AccountType.Checking:
                    Console.Write("Digite o valor da sua taxa: ");
                    double withdrawFee = double.Parse(Console.ReadLine());
                    Console.Write("Digite o valor do seu cheque especial: ");
                    double overdraftLimit = double.Parse(Console.ReadLine());
                    bank.AddAccount(new CheckingAccount(number, holder, balance, withdrawFee, overdraftLimit));
                    break;
                case AccountType.Business:
                    Console.Write("Digite o valor do seu limite de crédito: ");
                    double loanLimit = double.Parse(Console.ReadLine());
                    bank.AddAccount(new BusinessAccount(number, holder, balance, loanLimit));
                    break;
                case AccountType.Student:
                    Console.Write("Digite o valor do seu limite diário: ");
                    double dailyWithdrawLimit = double.Parse(Console.ReadLine());
                    bank.AddAccount(new StudentAccount(number, holder, balance, dailyWithdrawLimit));
                    break;
                case AccountType.Premium:
                    Console.Write("Digite o valor do seu Cashback: ");
                    double CashbackPercentage = double.Parse(Console.ReadLine());
                    bank.AddAccount(new PremiumAccount(number, holder, balance, CashbackPercentage));
                    break;
                default:
                    Console.WriteLine("Tipo de conta inválido.");
                    return;
            }
            Console.WriteLine("Conta criada com sucesso!");
            Console.WriteLine();
        }

        //2- Depositar
        public void Deposit(int number, double amount)
        {
          
            var depositAccount = GetAccount(number);
            depositAccount.Deposit(amount);
        }

        //3- Sacar
        public void Withdraw(int number, double amount)
        {
            var withdrawAccount = GetAccount(number);
            withdrawAccount.Withdraw(amount);
        }

        //4- Transferir
        public void Transfer(int fromNumber, int toNumber, double amount)
        {
            
            var fromAccount = GetAccount(fromNumber);
            var toAccount = GetAccount(toNumber);
            fromAccount.Transfer(toAccount, amount);
        }


        //5- Buscar Conta
        public Account GetAccount(int number)
        {
            return accounts.FirstOrDefault(a => a.Number == number);
        }


        //6- Listar todas as contas
        public void GetAllAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }
        }

        //7- Remover Conta
        public void RemoveAccount(Account account)
        {
            accounts.Remove(account);
        }

        // Validação de conta
        public void Validation(int number)
        {
       
            if (GetAccount(number) == null)
            {
                Console.WriteLine("Conta não encontrada");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }

        // Pré-cadastro de contas
        public void PreAccount()
        {
            var acc0 = new CheckingAccount(0, "AAA", 0, 0, 0);
            var acc1 = new CheckingAccount(1, "João", 5000, 5, 1000);
            var acc2 = new PremiumAccount(2, "Bob", 5000, 0.2);
            var acc3 = new BusinessAccount(3, "Carlos", 15000, 5000);
            var acc4 = new StudentAccount(4, "Laura", 450, 100);
            var acc5 = new CheckingAccount(5, "Alice", 3000, 10, 1000);
            var acc6 = new CheckingAccount(6, "Cleiton", 1000, 7, 3000);
            var acc7 = new PremiumAccount(7, "Pedro", 7777777777, 0.77);

            AddAccount(acc0);
            AddAccount(acc1);
            AddAccount(acc2);
            AddAccount(acc3);
            AddAccount(acc4);
            AddAccount(acc5);
            AddAccount(acc6);
            AddAccount(acc7);
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}
