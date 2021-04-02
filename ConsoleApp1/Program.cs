using System;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Customer client = new Customer();
            Bank bank = new Bank();

            bool i = true;
            if (client.IsBunkrupt) { i = false;}
            Bank.SendHello();
            ConsoleKeyInfo insertedConsoleKeyInfo = Console.ReadKey();
            char number = insertedConsoleKeyInfo.KeyChar;
            

            while (i == true)
            {
                switch (number)
                {
                    case '0':
                        if (client.IsBunkrupt)
                        {
                            i = false;
                            Bank.ClientIsBunkrupt();
                            break;
                        }
                        Bank.SendHello();
                        insertedConsoleKeyInfo = Console.ReadKey();
                        number = insertedConsoleKeyInfo.KeyChar;
                        break;
                    case '1':
                        Bank.SendARequestDeposit();
                        bank.ClientMoneyDeposit(client.ReplyToRequest(), ref client.cash);
                        //Console.ReadKey();
                        goto case '0';
                    case '2':
                        Bank.SendARequestWithdraw();
                        bank.ClientMoneyWithdraw(client.ReplyToRequest(), ref client.cash);
                        //Console.ReadKey();
                        goto case '0';
                    case '3':
                        //Console.ReadKey();
                        Bank.SendARequestInvest();
                        bool cycle = Bank.RespondToInvestRequest(client.ReplyToRequest());
                        if (cycle)
                        {
                            goto case '3';
                        }
                        
                        //Console.ReadKey();
                        Bank.SendARequestChoice();
                        bank.ClientMoneyInvesting(client.ReplyToRequest(),ref client.IsBunkrupt);
                        //Console.ReadKey();
                        goto case '0';
                    case '4':
                        Bank.SendARequestMoneyCheck(client.cash, bank.ClientMoney);
                        //Console.ReadKey();
                        goto case '0';
                    case '5':
                        i = false;
                        break;
                }
            }

        }
    }

    class Customer
    {
        public string status;
        public bool IsBunkrupt = false;
        public double cash=100;

        public void PutMoneyInABank(ref double cash, ref double cashInABank)
        {
            cashInABank += cash;
            cash = 0;
        }

        public void WithdrawMoneyFromABank(ref double cash, ref double cashInABank)
        {
            cash += cashInABank;
            cashInABank = 0;
        }

        public string ReplyToRequest()
        {
            string reply = Console.ReadLine();
            return reply;
        }

    }

    class Bank
    {
        public static double percent = 0;
        public static double commision = 5;
        public double ClientMoney = 0;
        public double InvestingMoney = 0;
       // public bool IsBunkrupt = false;

        public static void SendHello()
        {
            Console.WriteLine($"Greetings from our fancy bank, if you want to deposit your cash type \"1\" " +
                              $"if you want to withdraw your money type \"2\", if you want to invest your " +
                              $"money type \"3\", if you want to know how much overall money you have type \"4\", " +
                              $"if you want to leave the bank type \"5\"");
        }

        public static void ClientIsBunkrupt()
        {
            Console.WriteLine($"You are bunkrupt! Go away!");
        }

        public static void SendARequestMoneyCheck(double cash, double ClientMoney)
        {
            Console.WriteLine($"You currently have {cash} in cash and {ClientMoney} in a bank.");
        }

        public static void SendARequestInvest()
        {
            Bank.percentChange();
            Console.WriteLine($"Our proposed investing rates are: Bank commision is {commision}. " +
                              $"Do you want to invest your Bank money with a yearly rate of {percent} gain ? (Y/N)" +
                              $" ");
        }
        public static bool RespondToInvestRequest(string ClientMsg)
        {
        if (ClientMsg == "N" || ClientMsg == "n")
            {
                return true;
            }
            else
            {
                if (ClientMsg == "Y" || ClientMsg == "y")
                {
                    return false;
                }
                else
                {
                    ErrorHandler.ErrorReadLine();
                    return false;
                }
            }

        }

        public static void SendARequestDeposit()
        {
            Console.WriteLine($"Please type how much cash would you like to deposit. If you want to" +
                              $" deposit everything type \"F\". ");
        }

        public static void SendARequestWithdraw()
        {
            Console.WriteLine($"Please type how much cash would you like to withdraw. If you want to" +
                              $" withdraw everything type \"F\". ");
        }

        public static void SendARequestChoice()
        {
            Console.WriteLine($"Please type how much would you like to invest. If you want to invest" + 
                              $" everything type \"F\".");
        }

        public static void percentChange()
        {
            var rand = new Random();
            percent = 2*(rand.NextDouble())-1;
        }

        public void ClientMoneyInvesting(string ClientMsg, ref bool IsBunkrupt)
        {
            if (ClientMsg == "f" || ClientMsg == "F")
            {
                InvestingMoney += ClientMoney;
                ClientMoney = 0;
            }
            else
            {
                if (Convert.ToDouble(ClientMsg) > 0)
                {
                    InvestingMoney += Convert.ToDouble(ClientMsg);
                    ClientMoney -= Convert.ToDouble(ClientMsg);

                    InvestingMoney = (InvestingMoney) * (1 + percent) - commision;
                    ClientMoney += InvestingMoney;
                    InvestingMoney = 0;

                    if (ClientMoney < 0)
                    {
                        IsBunkrupt = true;
                    }
                }
                else
                {
                    ErrorHandler.ErrorReadLine();
                }
            }
        }

        public void ClientMoneyDeposit(string ClientMsg , ref double cashToDeposit)
        {

            if (ClientMsg == "f" || ClientMsg == "F")
            {
                ClientMoney += cashToDeposit;
                cashToDeposit = 0;
            }
            else
            {
                if (Convert.ToDouble(ClientMsg) > 0)
                {
                    ClientMoney += Convert.ToDouble(ClientMsg);
                    cashToDeposit -= Convert.ToDouble(ClientMsg);
                }
                else
                {
                    ErrorHandler.ErrorReadLine();
                }
            }
        }

        public void ClientMoneyWithdraw(string ClientMsg, ref double cashToWithdraw)
        {

            if (ClientMsg == "f" || ClientMsg == "F")
            {
                cashToWithdraw += ClientMoney;
                ClientMoney = 0;
            }
            else
            {
                if (Convert.ToDouble(ClientMsg) > 0)
                {
                    ClientMoney -= Convert.ToDouble(ClientMsg);
                    cashToWithdraw += Convert.ToDouble(ClientMsg);
                }
                else
                {
                    ErrorHandler.ErrorReadLine();
                }
            }
        }
    }

    class ErrorHandler
    {
        public static void ErrorReadLine()
        {
            Console.WriteLine("You have entered incorrect input. Please provide correct input.");
        }
    }
}
