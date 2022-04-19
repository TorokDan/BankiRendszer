namespace BankiRendszer
{
    public class Bank
    {
        private BankHashSet<string, BankAccount> _accounts;

        public Bank(int size, BankHashSet<string,BankAccount>.HashCallback hashFv = null) //A paraméterekkel lehet hogy még gond lesz
        {
            _accounts = new BankHashSet<string, BankAccount>(size, hashFv);
        }

        public Bank() // Lehet, h ezzel is gond lesz.
        {
            _accounts = new BankHashSet<string, BankAccount>();
        }

        public void Transaction(string from, string to, double amount)
        {
            _accounts.Find(from).Withdraw(amount);
            _accounts.Find(to).Deposit(amount);
        }

        public void RegisterAccount(string accountNumber, double deposit) 
            => _accounts.Insert(accountNumber, new BankAccount(accountNumber, deposit));
    }
}