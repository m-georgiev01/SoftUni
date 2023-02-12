using P05.ComparingObjects;

List<Person> people = new();

string personInfo;
while ((personInfo = Console.ReadLine()) != "END")
{
    var tokens = personInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = tokens[0];
    int age = int.Parse(tokens[1]);
    string town = tokens[2];

    people.Add(new Person(name, age, town));
}

int wantedPersonIdx = int.Parse(Console.ReadLine());

int countMatches = 0;
int countNonEqualPeople = 0;

foreach (var person in people)
{
    if (person.CompareTo(people[wantedPersonIdx - 1]) == 0)
    {
        countMatches++;
    }
    else
    {
        countNonEqualPeople++;
    }
}

Console.WriteLine(countMatches > 1 ? $"{countMatches} {countNonEqualPeople} {people.Count}" : "No matches");