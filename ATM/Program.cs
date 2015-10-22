using System;

class Program
{
    private static int cashInAtm=16500;
    private static int thousand=10, fiveHun=10, hun=10, fifty=10;
    private static int payThousand, payFiveHun, payHun, payFifty;
    public static void InitialMoney()
    {
        try
        {
            Console.Write("Enter the no. of Rs. 1000 notes: ");
            thousand = Convert.ToInt32(Console.ReadLine());
            cashInAtm += (1000 * thousand);
            Console.Write("Enter the no. of Rs. 500 notes: ");
            fiveHun = Convert.ToInt32(Console.ReadLine());
            cashInAtm += (500 * fiveHun);
            Console.Write("Enter the no. of Rs. 100 notes: ");
            hun = Convert.ToInt32(Console.ReadLine());
            cashInAtm += (100 * hun);
            Console.Write("Enter the no. of Rs. 50 notes: ");
            fifty = Convert.ToInt32(Console.ReadLine());
            cashInAtm += (50 * fifty);
        }
        catch(Exception e)
        {
            Console.WriteLine("\nEnter a valid integer number\n\n");
            InitialMoney();
        }
        Console.WriteLine("\nTotal money in ATM: Rs. " + cashInAtm);
    }

    static void PerformTransaction(int amount)
    {
        int should = amount;
        int got=0;
        if(amount>cashInAtm)
        {
            Console.WriteLine("Your amount is larger than currently available amount in ATM");
            return;
        }
        payThousand = amount / 1000;
        if (payThousand >= thousand && payThousand!=0)
        {
            payThousand = thousand;
            thousand = 0;
            amount -= (1000 * payThousand);
            cashInAtm -= (1000 * payThousand);
            got += (1000 * payThousand);
        }
        else
        {
            thousand -= payThousand;
            amount -= (1000 * payThousand);
            cashInAtm -= (1000 * payThousand);
            got += (1000 * payThousand);
        }
        payFiveHun = amount / 500;
        if (payFiveHun >= fiveHun && payFiveHun != 0)
        {
            payFiveHun = fiveHun;
            fiveHun = 0;
            amount -= (500 * payFiveHun);
            cashInAtm -= (500 * payFiveHun);
            got += (500 * payFiveHun);
        }
        else
        {
            fiveHun -= payFiveHun;
            amount -= (500 * payFiveHun);
            cashInAtm -= (500 * payFiveHun);
            got += (500 * payFiveHun);
        }
        payHun = amount / 100;
        if (payHun >= hun && payHun != 0)
        {
            payHun = hun;
            hun = 0;
            amount -= (100 * payHun);
            cashInAtm -= (100 * payHun);
            got += (100 * payHun);
        }
        else
        {
            hun -= payHun;
            amount -= (100 * payHun);
            cashInAtm -= (100 * payHun);
            got += (100 * payHun);
        }
        payFifty = amount / 50;
        if (payFifty >= fifty && payFifty != 0)
        {
            payFifty = fifty;
            fifty = 0;
            amount -= (50 * payFifty);
            cashInAtm -= (50 * payFifty);
            got += (50 * payFifty);
        }
        else
        {
            fifty -= payFifty;
            amount -= (50 * payFifty);
            cashInAtm -= (50 * payFifty);
            got += (50 * payFifty);
        }
        if(should == got)
        {
            Console.WriteLine("\nThe Bill is as follows:");
            Console.WriteLine("1000 X " + payThousand + " = " + (1000 * payThousand));
            Console.WriteLine("500 X " + payFiveHun + " = " + (500 * payFiveHun));
            Console.WriteLine("100 X " + payHun + " = " + (100 * payHun));
            Console.WriteLine("50 X " + payFifty + " = " + (50 * payFifty));
            Console.WriteLine("Total Amount: Rs. " + got);
            Console.WriteLine("Thank You for using HPES Bank");
        }
        else
        {
           Console.WriteLine("\nSorry, No Cash");
        }
        
    }

    static void Transaction()
    {
        int amount = 0;
           Console.Write("Enter the amount you want to withdraw: Rs. ");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("\nPlease enter a valid amount in number format\n\n");
                return;
            }
        if(cashInAtm==0)
        {
            Console.WriteLine("Sorry No cash");
            return;
        }
            if (amount > cashInAtm)
            {
                Console.WriteLine("\nYour amount is larger than currently available amount in ATM\n\n");
                return;
            }
            else
            {
                if(amount<0)
                {
                    Console.WriteLine("Enter a positive number");
                    return;
                }
                if(fifty!=0)
                {
                    if (amount % 50 == 0)
                        PerformTransaction(amount);
                    else
                    {
                        Console.WriteLine("Amount must be in multipe of 50");
                        return;
                    }
                }
                else if(hun!=0)
                {
                    if (amount % 100 == 0)
                        PerformTransaction(amount);
                    else
                    {
                        Console.WriteLine("Amount must be in multipe of 100");
                        return;
                    }
                }
                else if (fiveHun != 0)
                {
                    if (amount % 500 == 0)
                        PerformTransaction(amount);
                    else
                    {
                        Console.WriteLine("Amount must be in multipe of 500");
                        return;
                    }
                }
                else if (thousand != 0)
                {
                    if (amount % 1000 == 0)
                        PerformTransaction(amount);
                    else
                    {
                        Console.WriteLine("Amount must be in multipe of 1000");
                        return;
                    }
                }
                
            }
       }
    static void Main(string[] args)
    {
        string choice="Y";
        //InitialMoney();
        while(choice.Equals("y") || choice.Equals("Y"))
        {
            Transaction();
            Console.WriteLine("Do you want to continue your transaction:(Y/N)?: ");
            choice = Console.ReadLine();
        }
        
        Console.WriteLine("Press Enter to Continue");
        Console.Read();
    }
}
