using BankSystem.Accounts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankSystem
{
    public class AccountStorage
    {
        private static List<Account> accountList = new List<Account>();

        public static void Add(Account account)
        {
            accountList.Add(account);
        }

        public static void Remove(string id)
        {
            Account acc = GetByID(id);

            if (acc == null)
            {
                throw new ArgumentException();
            }

            accountList.Remove(acc);
        }

        public static void Save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, accountList);
            }
        }

        public static void Load(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("", FileMode.OpenOrCreate))
            {
                List<Account> list = (List<Account>)formatter.Deserialize(fs);

                accountList = list;
            }
        }

        public static Account GetByID(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            if (id == string.Empty)
            {
                throw new ArgumentException();
            }

            if (accountList.Count == 0)
            {
                return null;
            }

            foreach (Account account in accountList)
            {
                if (account.Account_ID == id)
                {
                    return account;
                }
            }

            return null;
        }
    }
}
