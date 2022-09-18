using System;

namespace P07.TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int pricePerTicket = 0;

            if (day == "Weekday")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    pricePerTicket = 12;
                }
                else if(age > 18 && age <= 64)
                {
                    pricePerTicket = 18;
                }
            }
            else if (day == "Weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    pricePerTicket = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    pricePerTicket = 20;
                }
            }
            else if (day == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    pricePerTicket = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    pricePerTicket = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    pricePerTicket = 10;
                }
            }

            if (pricePerTicket == 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{pricePerTicket}$");
            }
        }
    }
}
