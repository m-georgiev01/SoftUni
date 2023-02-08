using P07.Tuple;

string[] firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
OurTuple<string, string> t1 = new ($"{firstInput[0]} {firstInput[1]}", firstInput[2]);
Console.WriteLine(t1);

string[] secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
OurTuple<string, int> t2 = new(secondInput[0], int.Parse(secondInput[1]));
Console.WriteLine(t2);

string[] thirdInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
OurTuple<int, double> t3 = new(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));
Console.WriteLine(t3);