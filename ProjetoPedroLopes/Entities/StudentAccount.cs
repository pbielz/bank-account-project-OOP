using ProjetoPedroLopes.Entities.Enums;

namespace ProjetoPedroLopes.Entities
{
    internal class StudentAccount : Account
    {
        //limite diário de saque
        public double DailyWithdrawLimit { get; private set; }

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
                Console.WriteLine("Saque recusado: pedido de saque maior que o limite diário.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Saque recusado: saldo insuficiente.");
            }else
                Balance -= amount;
        }

        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo: {AccountType.Student}, limite diário: {DailyWithdrawLimit}";
        }
    }
}