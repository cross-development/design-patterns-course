namespace DesignPatterns.Solid;


public class Rectangle
{
    // Violation!!
    //public int Width { get; set; }
    // Violation!!
    //public int Height { get; set; }

    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle()
    {

    }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString()
    {
        return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
    }
}

public class Square : Rectangle
{
    // Violation!!
    //public new int Width
    //{
    //  set { base.Width = base.Height = value; }
    //}

    // Violation!!
    //public new int Height
    //{ 
    //  set { base.Width = base.Height = value; }
    //}

    public override int Width // nasty side effects
    {
        set { base.Width = base.Height = value; }
    }

    public override int Height
    {
        set { base.Width = base.Height = value; }
    }
}

public class LiskovSubstitutionPrinciple
{
    private static int Area(Rectangle r) => r.Width * r.Height;

    public static void RunDemo()
    {
        Rectangle rc = new Rectangle(2, 3);
        Console.WriteLine($"{rc} has area {Area(rc)}");

        // should be able to substitute a base type for a subtype
        /*Square*/
        Rectangle sq = new Square();
        sq.Width = 4;
        Console.WriteLine($"{sq} has area {Area(sq)}");
    }
}
