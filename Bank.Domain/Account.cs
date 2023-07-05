namespace Bank.Domain
{
    public class Account
    {
        public const string ERROR_AMOUNT_LESS_EQUAL_TO_CERO = "El monto no puede ser menor o igual a 0";
        public int AccountID { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public bool Active { get; private set; }
        public static Account Open(string _accountNumber)
        {
            return new Account()
            {
                AccountNumber = _accountNumber,
                Balance = 0,
                Active = true
            };
        }

        public static Account OpenWithInitialAmount(string _accountNumber, decimal _amount)
        {
            var account = Open(_accountNumber);
            account.Deposit(_amount);
            return account;
        }

        public void Deposit(decimal _amount)
        {
            if (_amount <= 0)
                throw new Exception (ERROR_AMOUNT_LESS_EQUAL_TO_CERO);
            Balance += _amount;
        }
        
        public void Withdraw(decimal _amount)
        {
            if (_amount <= 0)
                throw new Exception (ERROR_AMOUNT_LESS_EQUAL_TO_CERO);
            Balance -= _amount;
        }
    }
}