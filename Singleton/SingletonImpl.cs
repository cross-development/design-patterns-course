namespace DesignPatterns.Singleton;

public class SingletonImpl
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;

        private static Lazy<SingletonDatabase> _instance =
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => _instance.Value;

        private SingletonDatabase()
        {
            Console.WriteLine("Initializing database");

            _capitals = File.ReadAllLines("capitals.txt")
                .Chunk(2)
                .ToDictionary(
                    list => list.ElementAt(0),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }

    public static void RunDemo()
    {
        var db = SingletonDatabase.Instance;

        var city = "Tokyo";

        Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
    }
}
