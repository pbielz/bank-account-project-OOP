using ProjetoPedroLopes.Entities;
using ProjetoPedroLopes.Services;
using System;


namespace ProjetoPedroLopes
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BankService bank = new BankService();

            //contas pré cadastradas
            bank.PreAccount();
            Console.Write("Bem vindo ao Banco PG!");
            Console.ReadKey();

            int n = 0;
            while (n != 7)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Escolha uma das opções: ");
                Console.WriteLine("1. Criar uma conta.");
                Console.WriteLine("2. Depositar.");
                Console.WriteLine("3. Sacar.");
                Console.WriteLine("4. Consultar conta.");
                Console.WriteLine("5. Listar conta.");
                Console.WriteLine("6. Remover conta.");
                Console.WriteLine("7. Sair.");
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
                        Console.WriteLine("Digite o número da conta que deseja consultar");
                        int depositAccount = int.Parse(Console.ReadLine());

                        break;
                    case 3:
                        //Sacar


                        //Console.WriteLine("Quanto deseja sacar");
                        //double amount = double.Parse(Console.ReadLine());
                        //acc1.Withdraw(amount);
                        //Console.WriteLine("Novo saldo: " + acc1.Balance);
                        break;
                    case 4:
                        //Consultar conta
                        Console.WriteLine("Digite o número da conta que deseja consultar");
                        int getAccount = int.Parse(Console.ReadLine());
                        Console.WriteLine(bank.GetAccount(getAccount));
                        break;
                    case 5:
                        //Listar conta
                        bank.GetAllAccounts();
                        break;
                    case 6:
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
                    case 7:
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