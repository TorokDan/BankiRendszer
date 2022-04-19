namespace BankiRendszer
{
    public class BankAccount
    {
        private string _accountNumber;
        private double _money;  // itt lehet h float kell
        
        public string AccountNumber => _accountNumber;
        public double Money => _money;

        public BankAccount(string accountNumber, double money)
        {
            _accountNumber = accountNumber;
            _money = money;
        }

        public void Deposit(double amount) => _money += amount;
        public void Withdraw(double amount) => _money -= amount;
    }
}