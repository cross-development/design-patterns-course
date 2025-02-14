namespace DesignPatterns.Solid;

public enum Color
{
    Red,
    Green,
    Blue,
}

public enum Size
{
    Small,
    Medium,
    Large,
    Huge
}

public class Product
{
    public string Name;
    public Color Color;
    public Size Size;

    public Product(string name, Color color, Size size)
    {
        Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        Size = size;
        Color = color;
    }
}

//! Wrong approach. 
// We need to modify this class every time we want to use a new type of filter (by size, by color, or both)
public class ProductFilter
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach (var p in products)
        {
            if (p.Size == size)
            {
                yield return p;
            }
        }
    }

    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    {
        foreach (var p in products)
        {
            if (p.Color == color)
            {
                yield return p;
            }
        }
    }

    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
    {
        foreach (var p in products)
        {
            if (p.Color == color && p.Size == size)
            {
                yield return p;
            }
        }
    }
}

//! Correct approach
public interface ISpecification<T>
{
    bool IsSatisfied(T t);
}

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}


public class ColorSpecification : ISpecification<Product>
{
    private Color color;

    public ColorSpecification(Color color)
    {
        this.color = color;
    }

    public bool IsSatisfied(Product t)
    {
        return t.Color == color;
    }
}

public class SizeSpecification : ISpecification<Product>
{
    private Size size;

    public SizeSpecification(Size size)
    {
        this.size = size;
    }

    public bool IsSatisfied(Product t)
    {
        return t.Size == size;
    }
}

public class AndSpecification<T> : ISpecification<T>
{
    private ISpecification<T> first;

    private ISpecification<T> second;

    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
        this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
        this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
    }

    public bool IsSatisfied(T t)
    {
        return first.IsSatisfied(t) && second.IsSatisfied(t);
    }
}

public class BetterFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
        foreach (var item in items)
        {
            if (spec.IsSatisfied(item))
            {
                yield return item;
            }
        }
    }
}

public class OpenClosedPrinciple
{
    public static void RunDemo()
    {
        var apple = new Product("Apple", Color.Green, Size.Small);
        var tree = new Product("Tree", Color.Green, Size.Large);
        var house = new Product("House", Color.Blue, Size.Large);

        Product[] products = { apple, tree, house };

        // Wrong approach.
        var pf = new ProductFilter();

        Console.WriteLine("Green products (old): ");

        foreach (var p in pf.FilterByColor(products, Color.Green))
        {
            Console.WriteLine($" - {p.Name} is green");
        }


        Console.WriteLine("Large products (old): ");

        foreach (var p in pf.FilterBySize(products, Size.Large))
        {
            Console.WriteLine($" - {p.Name} is large");
        }

        // Correct approach
        var bf = new BetterFilter();

        Console.WriteLine("Green products (new): ");

        foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
        {
            Console.WriteLine($" - {p.Name} is green");
        }

        Console.WriteLine("Large products (new): ");

        foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
        {
            Console.WriteLine($" - {p.Name} is large");
        }

        Console.WriteLine("Large blue items");

        foreach (var p in bf.Filter(products, new AndSpecification<Product>(
            new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
        {
            Console.WriteLine($" - {p.Name} is large and blue");
        }
    }
}
