namespace DesignPatterns.Prototype;

public class ICloneableIsBad
{
    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public object Clone()
        {
            return new Person(Names, (Address)Address.Clone());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public static void RunDemo()
    {
        var john = new Person(new[] { "John", "Smith" }, new Address("Main St", 123));

        // var jane = john; // This is a shallow copy, not a deep copy
        // jane.Name[0] = "Jane"; // This will also change john's name

        var jane = (Person)john.Clone();
        jane.Address.HouseNumber = 321;

        Console.WriteLine("Jane " + jane);
        Console.WriteLine("John " + john);
    }
}
