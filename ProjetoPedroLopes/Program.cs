using ProjetoPedroLopes.Entities;
using ProjetoPedroLopes.Services;
using System;
using System.Security.Principal;


namespace ProjetoPedroLopes
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BankService bank = new BankService();
            //contas pré cadastradas
            bank.PreAccount();
            Console.Write("Bem vindo ao Banco PG! ");
            Console.ReadKey();


            var interestCalculator = new SimpleInterestCalculator(0.02);
            var loanService = new LoanService(interestCalculator);
            loanService.ProcessLoan(, 1000, 12);

            //Menu
            int n = 0;
            while (n != 7)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Escolha uma das opções: ");
                Console.WriteLine("1. Criar uma conta.");
                Console.WriteLine("2. Depositar.");
                Console.WriteLine("3. Sacar.");
                Console.WriteLine("4. Transferir.");
                Console.WriteLine("5. Consultar conta");
                Console.WriteLine("6. Listar conta. ");
                Console.WriteLine("7. Remover conta.");
                Console.WriteLine("8. Sair.");
                n = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (n)
                {
                    case 1:
                        //criar conta
                        BankService.CreateAccount(bank);
                        break;
                    case 2:
                        //Depositar
                        Console.WriteLine("Digite o número da conta que deseja depositar");
                        int depositAccount = int.Parse(Console.ReadLine());
                        bank.Validation(depositAccount);
                        //if (bank.GetAccount(depositAccount) == null)
                        //{
                        //    Console.WriteLine("Não há contas cadastradas para realizar a transferência.");
                        //    break;
                        //}
                        Console.WriteLine("Quanto deseja depositar?");
                        double depositAmount = double.Parse(Console.ReadLine());
                        bank.Deposit(depositAccount, depositAmount);
                        break;
                    case 3:
                        //Sacar
                        Console.WriteLine("Digite o número da conta que deseja sacar");
                        int withdrawAccount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Quanto deseja sacar?");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        bank.Withdraw(withdrawAccount, withdrawAmount);
                        break;
                    case 4:
                        //Transferir
                        Console.WriteLine("Digite o número da conta que quer tirar o dinheiro");
                        int fromAccount = int.Parse(Console.ReadLine());
                        if (bank.GetAccount(fromAccount) == null)
                        {
                            Console.WriteLine("Não há contas cadastradas para realizar a transferência.");
                            break;
                        }
                        Console.WriteLine("Digite o número da conta que quer receber o dinheiro");
                        int toAccount = int.Parse(Console.ReadLine());
                        if (bank.GetAccount(toAccount) == null)
                        {
                            Console.WriteLine("Conta destinatária não encontrada!");
                            break;
                        }
                        Console.WriteLine("Quanto deseja transferir?");
                        double transferAmount = double.Parse(Console.ReadLine());
                        bank.Transfer(fromAccount, toAccount, transferAmount);
                        break;
                    case 5:
                        //Consultar conta
                        Console.WriteLine("Digite o número da conta que deseja consultar");
                        int getAccount = int.Parse(Console.ReadLine());
                        if (bank.GetAccount(getAccount) == null)
                        {
                            Console.WriteLine("Conta não encontrada!");
                            break;
                        }
                        Console.WriteLine(bank.GetAccount(getAccount));
                        break;
                    case 6:
                        //Listar conta
                        bank.GetAllAccounts();

                        break;
                    case 7:
                        //Remover conta
                        Console.WriteLine("Digite o número da conta que você deseja remover: ");
                        int removeAccount = int.Parse(Console.ReadLine());
                        if (bank.GetAccount(removeAccount) == null)
                        {
                            Console.WriteLine("Conta não encontrada!");
                            break;
                        }
                        else
                        {
                            var remove = bank.GetAccount(removeAccount);
                            bank.RemoveAccount(remove);
                        }
                        break;
                    case 8:
                        //Sair
                        Console.WriteLine("Volte sempre!");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para reiniciar ");
                Console.ReadKey();
            }

        }



    }
}