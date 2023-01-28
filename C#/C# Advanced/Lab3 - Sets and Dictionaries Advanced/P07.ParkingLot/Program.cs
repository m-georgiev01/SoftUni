HashSet<string> carPark = new HashSet<string>();

string cmd;
while ((cmd = Console.ReadLine()) != "END")
{
    var cmdArgs = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string currCmd = cmdArgs[0];
    string carPlateNumber = cmdArgs[1];

    if (currCmd == "IN")
    {
        carPark.Add(carPlateNumber);
    }
    else if(currCmd == "OUT")
    {
        carPark.Remove(carPlateNumber);
    }
}

if (carPark.Any())
{
    foreach (var carPlateNum in carPark)
    {
        Console.WriteLine(carPlateNum);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}
