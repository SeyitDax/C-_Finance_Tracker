namespace AccountManagement{
    public class Account{
        private static int _nextId;

        public int ID {get; set;}
        public decimal Balance {get; set;}
        public decimal Debt {get; set;}

        public Account(decimal balance, decimal debt = 0)
        {
            Balance = balance;
            Debt = debt;
        }
    }
}