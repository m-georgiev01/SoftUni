using System;
using System.Collections.Generic;

namespace P07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var company = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" -> ");
                string companyName = cmdArgs[0];
                string employeeId = cmdArgs[1];

                if (!company.ContainsKey(companyName))
                {
                    company.Add(companyName, new List<string>());
                }

                if (!company[companyName].Contains(employeeId))
                {
                    company[companyName].Add(employeeId);
                }
            }

            foreach (var (companyName, employeesId) in company)
            {
                Console.WriteLine(companyName);
                foreach (var employeeID in employeesId)
                {
                    Console.WriteLine($"-- {employeeID}");
                }
            }
        }
    }
}
