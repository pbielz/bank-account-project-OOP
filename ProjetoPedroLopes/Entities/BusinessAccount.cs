using ProjetoPedroLopes.Entities.Enums;


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
                Console.WriteLine("Valor do saque deve ser positivo.");
            else if (Balance < total)
                Console.WriteLine("Saldo insuficiente para realizar o saque com taxa.");
            else
                Balance -= total;
        }

        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo: {AccountType.Business}, limite de empréstimo: {LoanLimit}";
        }
    }
}
