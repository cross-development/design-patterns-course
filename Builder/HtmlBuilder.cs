using System.Text;

namespace DesignPatterns.Builder;

public class HtmlElement
{
    private const int indentSize = 2;

    public string? Name;
    public string? Text;
    public List<HtmlElement> Elements = new();

    public HtmlElement() { }

    public HtmlElement(string name, string text)
    {
        Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);

        sb.AppendLine($"{i}<{Name}>");

        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * indent + 1));
            sb.AppendLine(Text);
        }

        foreach (var e in Elements)
        {
            sb.Append(e.ToStringImpl(indent + 1));
        }

        sb.AppendLine($"{i}</{Name}>");

        return sb.ToString();
    }

    public override string ToString() => ToStringImpl(0);
}

public class HtmlBuilder
{
    private readonly string _rootName;
    private HtmlElement root = new();

    public HtmlBuilder(string rootName)
    {
        root.Name = rootName;
        _rootName = rootName;
    }

    public HtmlBuilder AddChild(string childName, string childText)
    {
        var e = new HtmlElement(childName, childText);
        root.Elements.Add(e);

        return this;
    }

    public void Clear()
    {
        root = new HtmlElement { Name = _rootName };
    }

    public override string ToString() => root.ToString();
}

public class HtmlBuilderDemo
{
    public static void RunDemo()
    {
        var builder = new HtmlBuilder("ul");
        builder.AddChild("li", "hello").AddChild("li", "world");

        Console.WriteLine(builder);
    }
}
