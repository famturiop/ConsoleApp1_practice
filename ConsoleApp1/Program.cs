using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double money_in_bank = 0;
            double cash = 5;
            // var invest;
            var rand = new Random();
            // float percent = rand.Next(-1000, 1000)/1000;
            double percent = (rand.Next(-1000, 1000));
            percent = percent / 1000;
            int year = 0;
            double commision = 0.1;

            while (cash > 0 || money_in_bank > 0)
            {

                Console.WriteLine($"It is {year} year. " +
                                  $"You currently have {cash} in cash and {money_in_bank} in a bank. " +
                                  $"Bank commision is {commision}. " +
                                  $"Do you want to invest it with a yearly rate of {percent} gain ? (Y/N)");
                ConsoleKeyInfo insertedConsoleKeyInfo = Console.ReadKey();

                char invest = insertedConsoleKeyInfo.KeyChar;

                if (invest == 'Y' || invest == 'y')
                {
                    money_in_bank = (cash + money_in_bank) * (1 + percent) - commision;
                    cash = 0;
                }
                else
                {
                    cash += money_in_bank;
                    money_in_bank = 0;
                }

                percent = (rand.Next(-1000, 1000));
                percent = percent / 1000;
                year++;
            }

            Console.WriteLine("Congratulations! You are bankrupt.");
        }
    }

    class Customer
    {
        private string status;
        private bool IsBunkrupt;
        private double cash;

        void PutMoneyInABank(ref double cash, ref double cashInABank)
        {
            cashInABank = cash + cashInABank;
            cash = 0;
        }

        void WithdrawMoneyFromABank(ref double cash, ref double cashInABank)
        {
            cash = cash + cashInABank;
            cashInABank = 0;
        }

        char ReplyToRequest()
        {
            ConsoleKeyInfo insertedConsoleKeyInfo = Console.ReadKey();
            char reply = insertedConsoleKeyInfo.KeyChar;
            return reply;
        }

    }

    class Bank
    {
        private double percent;
        private double commision;
        private double ClientMoney;

    }

}
