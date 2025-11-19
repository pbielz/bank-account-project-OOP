
namespace ProjetoPedroLopes.Entities
{
    abstract class Account
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
                Console.WriteLine("Saque recusado: O valor do saque deve ser positivo.");
            }
            else
            Balance -= amount;
        }

        //Método depósito
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Depósito recusado: O valor do depósito deve ser positivo.");
            }
            Balance += amount;
        }

        //Método transferência
        public void Transfer(Account target, double amount)
        {
            this.Withdraw(amount);
            target.Deposit(amount);
        }

        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}";
        }
    }
}
