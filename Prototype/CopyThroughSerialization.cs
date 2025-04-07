using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatterns.Prototype;

public static class ExtensionMethods1
{
    // public static T DeepCopy<T>(this T self)
    // {
    //     var stream = new MemoryStream();
    //     var formatter = new BinaryFormatter();

    //     formatter.Serialize(stream, self);
    //     stream.Seek(0, SeekOrigin.Begin);
    //     object copy = formatter.Deserialize(stream);
    //     stream.Close();

    //     return (T)copy;
    // }

    public static T DeepCopyXml<T>(this T self)
    {
        using var ms = new MemoryStream();

        var s = new XmlSerializer(typeof(T));
        s.Serialize(ms, self);
        ms.Position = 0;
        return (T)s.Deserialize(ms)!;
    }
}

public class CopyThroughSerialization
{
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person() { }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address() { }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public static void RunDemo()
    {
        var john = new Person(new[] { "John", "Smith" }, new Address("Main St", 123));

        var jane = john.DeepCopyXml();
        jane.Names[0] = "Jane";
        jane.Address.HouseNumber = 321;

        Console.WriteLine("Jane " + jane);
        Console.WriteLine("John " + john);
    }
}
