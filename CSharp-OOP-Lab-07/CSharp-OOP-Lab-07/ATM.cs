using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharp_OOP_Lab_07
{
    internal class ATM
    {
        private List<Account> accounts = new List<Account>();
        public ATM()
        {
            this.Accounts = accounts;
        }
        public List<Account> Accounts { get => accounts; set => accounts = value; }
        public void PrintAccounts(List<Account> acc)
        {
            //8 15 17
            Console.WriteLine("+--------+---------------+-----------------+");
            Console.WriteLine($"|{"UserName",-8}|{"Number Phone",-15}|{"Balance",-17}|");
            Console.WriteLine("+--------+---------------+-----------------+");
            foreach (Account account in acc)
            {
                Console.WriteLine($"|{account.Username,-8}|{account.Numberphone,-15}|{account.Balance,-17}|");
            }
            Console.WriteLine("+--------+---------------+-----------------+");
        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public bool CheckAccount(string name)
        {
            foreach (Account account in Accounts)
            {
                if (name != null)
                {
                    if (account.Username == name) return true;
                }
            }
            return false;
        }

        public Account TransformToAccount(string user_name)
        {
            foreach (Account account in Accounts)
            {
                if (account.Username == user_name)
                    return account;
            }
            return null;
        }

        // Delegate để xử lí sự kiện
        public delegate void Transaction(string message);

        // Sự kiện kích hoạt khi có giao dịch
        public event Transaction HaveTransaction;

        public void Draw(string username, decimal amount)
        {
            Account acc = TransformToAccount(username);

            if (amount > acc.Balance)
            {
                Console.WriteLine("Không Đủ Tiền.");
            }
            else
            {
                acc.Balance -= amount;
                HaveTransaction?.Invoke($"Đã rút {amount} VND từ tài khoản {acc.Username}.\nSố dư còn lại: {acc.Balance} VND.\n");
                SendSMS(acc, "Đã rút", amount);
            }
        }
        public void Transfer(string sender, string receiver, decimal amount)
        {
            Account send = TransformToAccount(sender);
            Account recei = TransformToAccount(receiver);

            if (amount > send.Balance)
            {
                Console.WriteLine("Số dư không đủ.");
            }
            else
            {
                send.Balance -= amount;
                recei.Balance += amount;
                HaveTransaction?.Invoke($"Đã chuyển {amount} VND từ tài khoản {send.Username} đến tài khoản {recei.Username}.\nSố dư còn lại: {send.Balance} VND.\n");
                SendSMS(send, "Đã chuyển", amount);
            }
        }
        // Phương thức gửi tin nhắn
        private void SendSMS(Account account, string transactionType, decimal amount)
        {
            Console.WriteLine($"Tin nhắn: Tài khoản {account.Username} {transactionType} {amount} VND. Số điện thoại nhận: {account.Numberphone}");
        }

    }
}
