namespace AccountManagement{
    public class Account{
        public decimal Balance;
        public decimal Debt;

        public Account(decimal balance, decimal debt = 0)
        {
            Balance = balance;
            Debt = debt;
        }
    }
}