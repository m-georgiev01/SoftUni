using System;

namespace P08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int totalExamTimeInMinutes = examHour * 60 + examMinutes;
            int totalArrivalTimeInMinutes = arrivalHour * 60 + arrivalMinutes;

            int hours = 0;
            int minutes = 0;
            int difference = 0;

            if (totalExamTimeInMinutes < totalArrivalTimeInMinutes)
            {
                Console.WriteLine("Late");

                difference = totalArrivalTimeInMinutes - totalExamTimeInMinutes;
                hours = difference / 60;
                minutes = difference % 60;

                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{hours}:{minutes:D2} hours after the start");
                }             

            }
            else if ((totalExamTimeInMinutes - totalArrivalTimeInMinutes) >= 0 && (totalExamTimeInMinutes - totalArrivalTimeInMinutes) <= 30)
            {
                Console.WriteLine("On time");

                if (totalExamTimeInMinutes - totalArrivalTimeInMinutes != 0)
                {
                    difference = totalExamTimeInMinutes - totalArrivalTimeInMinutes;
                    Console.WriteLine($"{difference} minutes before the start");
                }
            }
            else if((totalExamTimeInMinutes - totalArrivalTimeInMinutes) > 30)
            {
                Console.WriteLine("Early");
                difference = totalExamTimeInMinutes - totalArrivalTimeInMinutes;

                hours = difference / 60;
                minutes = difference % 60;

                if (difference < 60)
                {
                    Console.WriteLine($"{difference} minutes before the start");                    
                }
                else
                {
                    Console.WriteLine($"{hours}:{minutes:D2} hours before the start");
                }
            }
        }
    }
}
