using System;

namespace BankSystem.Accounts
{
    [Serializable]
    public abstract class Account
    {
        protected string account_Id;
        protected string name;
        protected string lastName;
        protected double balance;
        protected int bPoints;

        protected Account(string name, string lastName)
        {
            if (name == null || lastName == null)
            {
                throw new ArgumentNullException();
            }

            if (name.Length <= 1 || lastName.Length <= 1)
            {
                throw new ArgumentNullException();
            }

            this.name = name;
            this.lastName = lastName;
            Random rnd = new Random();
            this.account_Id = rnd.Next(1, 1000).ToString();
        }

        internal string Account_ID
        {
            get
            {
                return account_Id;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    account_Id = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
        }

        internal double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    balance = value;
                }
            }
        }

        public int BPoints
        {
            get
            {
                return bPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    bPoints = value;
                }
            }
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            balance += amount;
            UpdateBonusPoints(amount);
        }

        public void Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            if (balance - amount < 0)
            {
                throw new ArgumentException();
            }

            balance -= amount;
            UpdateBonusPoints(amount);
        }

        protected abstract void UpdateBonusPoints(int amount);
    }
}
