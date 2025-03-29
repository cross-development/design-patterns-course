namespace DesignPatterns.Builder;

class Person
{
    public string Name { get; set; }
    public string Position { get; set; }

    public class Builder : PersonJobBuilder<Builder>
    {

    }

    public static Builder New => new Builder();

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
    }
}

public abstract class PersonBuilder
{
    protected Person person = new();

    public Person Build()
    {
        return person;
    }
}

public class PersonInfoBuilder<SELF> : PersonBuilder
    where SELF : PersonInfoBuilder<SELF>
{
    // Doesn't work with class inhabitance 
    // public PersonInfoBuilder Called(string name)
    public SELF Called(string name)
    {
        person.Name = name;
        return (SELF)this;
    }
}

public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
    where SELF : PersonJobBuilder<SELF>
{
    // Doesn't work with class inhabitance 
    // public PersonJobBuilder WorksAs(string position)
    public SELF WorksAs(string position)
    {
        person.Position = position;
        return (SELF)this;
    }
}

public class FluentBuilder
{
    public static void RunDemo()
    {
        var me = Person.New.Called("Vitalii").WorksAs("developer").Build();

        Console.WriteLine(me);
    }
}
