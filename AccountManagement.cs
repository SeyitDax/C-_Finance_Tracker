using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace AccountManagement{
    public interface IAccountRepository{
        Account Add(Account account);
        Account? GetById(int id);
        IEnumerable<Account> GetAll();
    }

    public class InMemoryAccountRepository : IAccountRepository{
        private readonly Dictionary<int, Account> _accounts = new();
        private int _nextId; 

        public Account Add(Account account){
            account.ID = Interlocked.Increment(ref _nextId);
            _accounts[account.ID] = account;
            return account;
        }

        public Account? GetById(int id) => _accounts.TryGetValue(id, out var acc) ? acc : null;
        public IEnumerable<Account> GetAll() => _accounts.Values;
    }

    public class JsonAccountRepository : IAccountRepository { 
        private readonly string _path; 
        private readonly Dictionary<int, Account> _accounts;
        private int _nextId; 
        public JsonAccountRepository(string path) { _path = path;
        if (File.Exists(_path))
            {
                var data = JsonSerializer.Deserialize<List<Account>>(File.ReadAllText(_path))?? new();
                _accounts = data.ToDictionary(a => a.ID);
                _nextId = _accounts.Keys.DefaultIfEmpty(0).Max();
            }
            else
            {
                _accounts = new Dictionary<int, Account>(); 
                _nextId = 0;
            }
        }

        public Account Add(Account account)
        {
            account.ID = Interlocked.Increment(ref _nextId);
            _accounts[account.ID] = account;
            _accounts[account.ID].Password = account.Password;
            Persist();
            return account;
        }

        public Account? GetById(int id) => _accounts.TryGetValue(id, out var acc) ? acc : null;

        public Account? GetByCreds(int id, string password){
            _accounts.TryGetValue(id, out var acc);

            if(acc != null && acc.Password == password)
            return acc;

            Console.WriteLine("Invalid Credentials");
            return null;
        }
        public IEnumerable<Account> GetAll() => _accounts.Values;

        private void Persist()
        {
            var list = _accounts.Values.OrderBy(a => a.ID).ToList();
            File.WriteAllText(_path, JsonSerializer.Serialize(list, new JsonSerializerOptions {WriteIndented = true }));
        }
    }
    public class Account{
        public string Password {get; set;}
        public int ID {get; set;}
        public decimal Balance {get; set;}
        public decimal Debt {get; set;}

        public Account(decimal balance, string password, decimal debt = 0){
            Password = password;
            Balance = balance;
            Debt = debt;
        }
    }
}