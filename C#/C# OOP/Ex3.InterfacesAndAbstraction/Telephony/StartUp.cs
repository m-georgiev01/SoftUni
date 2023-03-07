using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable;

            foreach (var phoneNumber in phoneNums)
            {

                if (phoneNumber.Length == 10)
                {
                    callable = new Smartphone();
                }
                else
                {
                    callable = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(callable.Call(phoneNumber));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsable browsable = new Smartphone();

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
