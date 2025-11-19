using ProjetoPedroLopes.Entities.Enums;

namespace ProjetoPedroLopes.Entities
{
    internal class CheckingAccount : Account
    {

        //taxa de saque
        public double WithdrawFee { get; private set; }
        //limite de cheque especial
        public double OverdraftLimit { get; private set; }

        public CheckingAccount() { }
        public CheckingAccount(int number, string holder, double balance, double withdrawFee, double overdraftLimit) : base(number, holder, balance)
        {
            WithdrawFee = withdrawFee;
            OverdraftLimit = overdraftLimit;
        }

        //método saque sobrescrito
        public override void Withdraw(double amount)
        {
            double total = amount + WithdrawFee;

            if (Balance + OverdraftLimit <= total)
                Console.WriteLine("Saque recusado: saldo insuficiente, incluindo limite de cheque especial.");
            else
                Balance -= total;


        }

        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo: {AccountType.Checking}, taxa: {WithdrawFee}, cheque especial:{OverdraftLimit}";
        }
    }
}