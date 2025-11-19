using ProjetoPedroLopes.Entities.Enums;

namespace ProjetoPedroLopes.Entities
{
    internal class PremiumAccount : Account
    {
        //percentual de cashback
        public double CashbackPercentage { get; private set; }

        //Construtores
        public PremiumAccount() { }
        public PremiumAccount(int number, string holder, double balance, double cashbackPercentage)
            : base(number, holder, balance)
        {
            CashbackPercentage = cashbackPercentage;
        }

        //método saque sobrescrito
        public override void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Saldo insuficiente.");
            }
            else
            {
                Balance -= amount; // sem taxa de saque
                ApplyCashback(amount);
            }
        }

        //método para aplicar cashback
        public void ApplyCashback(double purchaseAmount)
        {
            double cashback = (purchaseAmount * CashbackPercentage);
            Balance += cashback;
        }

       
        override public string ToString()
        {
            return $"Conta: {Number}, Proprietário(a): {Holder}, Saldo: ${Balance:F2}, tipo: {AccountType.Premium}, cashback:{CashbackPercentage}";
        }
    }
}
