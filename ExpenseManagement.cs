using AccountManagement;
namespace ExpenseManagement{

    public class Expense{
        private static int _nextId {get; set;}
        public int ID;
        public decimal Amount;
        public DateTime Time;
        public string? Note;

        public Expense(Account account,decimal amount, string note = null)
        {
            ID = System.Threading.Interlocked.Increment(ref _nextId);
            Amount = amount;
            Note = note;

            if(account.Balance >= amount){
                account.Balance -= amount;
            }
            else{
                amount -= account.Balance; account.Balance = 0; account.Debt = amount;
            }
        }
    }   
}