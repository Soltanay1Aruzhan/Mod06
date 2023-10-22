using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bankomat;

namespace Mod06prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            Account account = new Account();
            Registration(client, account);
        }
        public static void Registration(Client client, Account account)
        {

            Console.Write("Введите имя: ");
            client.FName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            client.LName = Console.ReadLine();

            Console.Write("Введите пол: ");
            client.Gender = Console.ReadLine();

            Console.Write("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
            string input = Console.ReadLine();
            DateTime dob;
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob))
                client.Date = dob;

            account.AccountNumber = Banc.CreateAccountNumber();
            account.Password = Banc.CreatePassword();

            Console.WriteLine($"Ваш номер счета: {account.AccountNumber}");
            Console.WriteLine($"Ваш пароль: {account.Password}");

            Console.WriteLine("Положите сумму на счет: ");
            account.Balance = Convert.ToDouble(Console.ReadLine());

            Authorization(client, account);
        }
        public static void Authorization(Client client, Account account)
        {
            int attempts = 3;

            while (attempts > 0)
            {

                Console.Write("Введите номер счета: ");
                string AccNum = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string Password = Console.ReadLine();

                if (account.AccountNumber == AccNum || account.Password == Password)
                {
                    Console.WriteLine("Приветствую тебя, " + client.FName);
                    Thread.Sleep(5000);
                    Menu(account);

                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Неверный номер счета или пароль. Осталось попыток: {attempts}");
                }
            }
            if (attempts == 0)
            {
                Console.WriteLine("Исчерпаны все попытки.");
            }

        }
        public static void Menu(Account account)
        {
            Console.Clear();
            Console.WriteLine("1) Вывод баланса на экран");
            Console.WriteLine("2) Пополнение счета");
            Console.WriteLine("3) Снять деньги со счета");
            Console.WriteLine("4) Выход");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    GetBlance(account);
                    break;
                case 2:
                    Replenishment(account);
                    break;
                case 3:
                    WithdrawMoney(account);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void GetBlance(Account account)
        {
            Console.WriteLine($"Ваш баланс составляет: {account.Balance}");
            Console.WriteLine("1) Вернуться в меню");
            Console.WriteLine("2) Выход");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Menu(account);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void Replenishment(Account account)
        {
            Console.Write("Пополнение на сумму: ");
            double T = Convert.ToDouble(Console.ReadLine());
            account.Balance += T;
            Console.WriteLine($"Ваша сумма на данный момент составляет: {account.Balance}");
            Console.WriteLine("1) Вернуться в меню");
            Console.WriteLine("2) Выход");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Menu(account);
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void WithdrawMoney(Account account)
        {
            Console.Write("Введите сумму которую хотите снять: ");
            double T = Convert.ToDouble(Console.ReadLine());
            if (T > account.Balance)
            {
                Console.WriteLine("Сумма для снятия превышает сумму счета");
                Thread.Sleep(5000);
                Menu(account);
            }
            else
            {
                account.Balance -= T;
                Console.WriteLine("Сумма снята со счета");
                Console.WriteLine($"Ваша сумма на данный момент составляет: {account.Balance}");
                Thread.Sleep(5000);
                Menu(account);
            }
        }
    }
}
