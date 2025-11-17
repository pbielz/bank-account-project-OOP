using ProjetoPedroLopes.Entities;
using System;


namespace ProjetoPedroLopes
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Account acc1 = new CheckingAccount(1001, "Pedro", 5000, 5, 1000);


            int n = 0;
            while (n != 5)
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao Banco PG!");
                Console.WriteLine();
                Console.WriteLine("Escolha uma das opções: ");
                Console.WriteLine("1. Criar uma conta.");
                Console.WriteLine("2. Depositar.");
                Console.WriteLine("3. Sacar.");
                Console.WriteLine("4. Consultar conta.");
                Console.WriteLine("5. Listar conta.");
                Console.WriteLine("5. Sair.");
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Que tipo de conta você quer criar: ");
                        Console.WriteLine("Corrente, Poupança ou Empresarial (c/p/e)");
                        break;
                    case 2:

                        break;
                    case 3:
                        Console.WriteLine("Quanto deseja sacar");
                        double amount = double.Parse(Console.ReadLine());
                        acc1.Withdraw(amount);
                        Console.WriteLine("Novo saldo: " + acc1.Balance);
                        break;
                    case 4:
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine("Volte sempre!");
                        break;
                }
                Console.WriteLine();
                Console.Write("Deseja usar os serviços do banco novamente? (s/n): ");
                string reiniciar = Console.ReadLine();
                if (reiniciar == "n")
                {
                     break;
                }
                Console.ReadKey();
            }




















            // Account acc2 = new CheckingAccount(1002, "Gabriel", 500, 0.01);
            List<Account> lista = new List<Account>();
            lista.Add(new SavingAccount(1003, "João", 1000, 0.01));

            Console.WriteLine(lista[0]);

            //   acc2.Withdraw(10);

            Console.WriteLine(acc1.Balance);
            //  Console.WriteLine(acc2.Balance);
        }
    }
}