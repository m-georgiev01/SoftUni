using System;
using System.Text;

namespace P01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stops = new StringBuilder(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];

                if (currCmd == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string newStop = cmdArgs[2];

                    if (index > 0 && index <= stops.Length)
                    {
                        stops.Insert(index, newStop);
                    }
                }
                else if (currCmd == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    if ((startIndex > 0 && startIndex < stops.Length) &&
                        (endIndex > 0 && endIndex < stops.Length))
                    {
                        int lenght = endIndex - startIndex + 1;

                        stops.Remove(startIndex, lenght);
                    }
                }
                else if (currCmd == "Switch")
                {
                    string oldStop = cmdArgs[1];
                    string newStop = cmdArgs[2];


                    stops.Replace(oldStop, newStop);

                }
                Console.WriteLine(stops.ToString().Trim());
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops.ToString()}");
        }
    }
}
