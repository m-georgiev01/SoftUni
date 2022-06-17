using System;

namespace P04.CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaucher = int.Parse(Console.ReadLine());

            int ticketsCount = 0;
            int otherPurchasesCount = 0;
            double spent = 0;

            string purchase = Console.ReadLine();

            while (purchase != "End")
            {      
                if (purchase.Length > 8)
                {              
                    spent += (int)purchase[0] + (int)purchase[1];
                    if (spent > vaucher)
                    {
                        break;
                    }
                    ticketsCount++;
                }
                else if (purchase.Length <= 8)
                {
                    spent += purchase[0];
                    if (spent > vaucher)
                    {
                        break;
                    }
                    otherPurchasesCount++;
                }
                purchase = Console.ReadLine();
            }

            Console.WriteLine(ticketsCount);
            Console.WriteLine(otherPurchasesCount);
        }
    }
}
