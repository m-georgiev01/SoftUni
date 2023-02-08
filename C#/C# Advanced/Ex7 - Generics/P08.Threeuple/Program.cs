using P08.Threeuple;

string[] firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Threeuple<string, string, string> t1 = new($"{firstInput[0]} {firstInput[1]}", firstInput[2], firstInput[3]);
Console.WriteLine(t1);

string[] secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Threeuple<string, int, bool> t2 = new(secondInput[0], int.Parse(secondInput[1]), secondInput[2] == "drunk");
Console.WriteLine(t2);

string[] thirdInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Threeuple<string, double, string> t3 = new(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);
Console.WriteLine(t3);