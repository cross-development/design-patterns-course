using System.Text;

namespace DesignPatterns.Builder;

public class LifeWithoutBuilder
{
    public static void RunDemo()
    {
        var hello = "hello";

        var sb = new StringBuilder();

        sb.Append("<p>");
        sb.Append(hello);
        sb.Append("</p>");

        Console.WriteLine(sb);

        sb.Clear();

        var words = new[] { "hello", "world" };

        sb.Append("<ul>");

        foreach (var word in words)
        {
            sb.AppendFormat("<li>{0}</li>", word);
        }

        sb.Append("</ul>");

        Console.WriteLine(sb);
    }
}
