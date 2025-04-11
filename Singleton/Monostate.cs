namespace DesignPatterns.Singleton;

public class Monostate
{
    public class ChiefExecutiveOfficer
    {
        private static string _name = null!;
        private static int age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    public static void RunDemo()
    {
        var ceo = new ChiefExecutiveOfficer();
        ceo.Name = "Adam Smith";
        ceo.Age = 55;

        var ceo2 = new ChiefExecutiveOfficer();
        Console.WriteLine(ceo2);
    }
}
