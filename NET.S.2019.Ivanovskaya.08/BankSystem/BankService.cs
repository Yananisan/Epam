using BankSystem.Accounts;
using System;

namespace BankSystem
{
    class BankService
    {
        public enum AccountType
        {
            Base,
            Gold,
            Platinum
        }

        public void Create(AccountType type, string name, string lastname)
        {
            if (name == null || lastname == null)
            {
                throw new ArgumentNullException("Parametrs can't be null");
            }

            if (name.Length <= 1 || lastname.Length <= 1)
            {
                throw new ArgumentNullException("Parametrs can't be empty or less then 1");
            }

            switch (type)
            {
                case AccountType.Base:
                    AccountStorage.Add(new BaseAccount(name, lastname));
                    break;
                case AccountType.Gold:
                    AccountStorage.Add(new GoldAccount(name, lastname));
                    break;
                case AccountType.Platinum:
                    AccountStorage.Add(new PlatinumAccount(name, lastname));
                    break;
            }
        }

        public static void CheckId(string id)
        {
            if (id == null)
            {
                throw new ArgumentException();
            }

            if (Int32.Parse(id) < 1 || Int32.Parse(id) > 1000)
            {
                throw new ArgumentException();
            }
        }

        public void Delete(string id)
        {
            CheckId(id);
            AccountStorage.Remove(id);
        }

        public void Deposit(string id, int amount)
        {
            CheckId(id);
            AccountStorage.GetByID(id).Deposit(amount);
        }

        public void Withdraw(string id, int amount)
        {
            CheckId(id);
            AccountStorage.GetByID(id).Withdraw(amount);
        }

        public void Save(string filename)
        {
            AccountStorage.Save(filename);
        }

        public void Load(string filename)
        {
            AccountStorage.Load(filename);
        }
    }
}
