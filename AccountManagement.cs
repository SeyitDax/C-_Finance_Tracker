namespace AccountManagement{
    public class Account{
        public static decimal Balance;
        public static decimal Debt;

        public Account(decimal balance, decimal debt = 0)
        {
            Balance = balance;
            Debt = debt;
        }
    }
}