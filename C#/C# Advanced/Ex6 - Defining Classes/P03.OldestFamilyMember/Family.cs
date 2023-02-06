namespace DefiningClasses;

public class Family
{
    private List<Person> members { get; set; }

    public Family()
    {
        members = new();
    }

    public void AddMember(Person p)
    {
        members.Add(p);
    }

    public Person GetOldestMember()
    {
        return members.MaxBy(x => x.Age);
    }
}