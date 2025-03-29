namespace DesignPatterns.Builder;

public class Person2
{
    // address
    public string StreetAddress { get; set; }
    public string Postcode { get; set; }
    public string City { get; set; }

    // employment
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public int AnnualIncome { get; set; }

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}";
    }
}

public class PersonBuilder2 // facade
{
    // should be a reference type!
    protected Person2 person = new();

    public PersonJobBuilder Works => new PersonJobBuilder(person);

    public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

    public static implicit operator Person2(PersonBuilder2 pb) => pb.person;
}

public class PersonJobBuilder : PersonBuilder2
{
    // might not work with a value type!
    public PersonJobBuilder(Person2 person)
    {
        this.person = person;
    }

    public PersonJobBuilder At(string companyName)
    {
        person.CompanyName = companyName;
        return this;
    }

    public PersonJobBuilder AsA(string position)
    {
        person.Position = position;
        return this;
    }

    public PersonJobBuilder Earning(int amount)
    {
        person.AnnualIncome = amount;
        return this;
    }
}

public class PersonAddressBuilder : PersonBuilder2
{
    // might not work with a value type!
    public PersonAddressBuilder(Person2 person)
    {
        this.person = person;
    }

    public PersonAddressBuilder At(string streetAddress)
    {
        person.StreetAddress = streetAddress;
        return this;
    }

    public PersonAddressBuilder WithPostcode(string postcode)
    {
        person.Postcode = postcode;
        return this;
    }

    public PersonAddressBuilder In(string city)
    {
        person.City = city;
        return this;
    }
}

public class FacetedBuilder
{
    public static void RunDemo()
    {
        Person2 person = new PersonBuilder2()
            .Lives.At("123 London Road").In("London").WithPostcode("SQ12AC")
            .Works.At("Fabrikam").AsA("Engineer").Earning(123000);

        Console.WriteLine(person);
    }
}
