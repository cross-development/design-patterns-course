using System.Diagnostics;

namespace DesignPatterns.Solid;

public class Journal
{
    private readonly List<string> entries = new List<string>();
    private static int count = 0;

    public int AddEntry(string text)
    {
        entries.Add($"{++count} {text}");

        return count;
    }

    public void RemoveEntry(int index)
    {
        entries.RemoveAt(index);
    }

    override public string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }

    //* Instead of keeping these methods here in the Journal class,
    //* we move them to a separate class (Persistence)
    // public void Save(string filename)
    // {
    //     File.WriteAllText(filename, ToString());
    // }

    // public static Journal Load(string filename)
    // {

    // }
}

public class Persistence
{
    public void SaveToFile(Journal journal, string filename, bool overwrite = false)
    {
        if (overwrite || !File.Exists(filename))
        {
            File.WriteAllText(filename, journal.ToString());
        }
    }
}

// A typical class is responsible for one thing and has one reason to change
public static class SingleResponsibilityPrinciple
{
    public static void RunDemo()
    {
        var journal = new Journal();

        journal.AddEntry("I cried today");
        journal.AddEntry("I ate a bag");

        Console.WriteLine(journal);

        var persistence = new Persistence();

        var filename = @"c:\temp\journal.txt";
        persistence.SaveToFile(journal, filename, true);

        Process.Start(filename);
    }
}
