namespace DesignPatterns.Builder;

public class Person1
{
    public string Name { get; set; }
    public string Position { get; set; }
}

public abstract class Builder<TSubject, TSelf>
    where TSelf : Builder<TSubject, TSelf> where TSubject : new()
{
    private readonly List<Func<Person1, Person1>> actions = new();

    public TSelf Do(Action<Person1> action) => AddAction(action);

    public Person1 Build() => actions.Aggregate(new Person1(), (p, f) => f(p));

    private TSelf AddAction(Action<Person1> action)
    {
        actions.Add(p =>
        {
            action(p);
            return p;
        });

        return (TSelf)this;
    }
}

public sealed class PersonBuilder1 : Builder<Person1, PersonBuilder1>
{
    public PersonBuilder1 Called(string name) => Do(p => p.Name = name);
}

// public sealed class PersonBuilder1
// {
// private readonly List<Func<Person1, Person1>> actions = new();

// public PersonBuilder1 Called(string name) => Do(p => p.Name = name);

// public PersonBuilder1 Do(Action<Person1> action) => AddAction(action);

// public Person1 Build() => actions.Aggregate(new Person1(), (p, f) => f(p));

// private PersonBuilder1 AddAction(Action<Person1> action)
// {
//     actions.Add(p =>
//     {
//         action(p);
//         return p;
//     });

//     return this;
// }
// }

public static class PersonBuilder1Extensions
{
    public static PersonBuilder1 WorksAs(this PersonBuilder1 builder, string position)
    {
        return builder.Do(p => p.Position = position);
    }
}

public class FunctionalBuilder
{
    public static void RunDemo()
    {
        var person = new PersonBuilder1()
        .Called("Sarah")
        .WorksAs("Developer")
        .Build();

        Console.WriteLine(person);
    }
}
