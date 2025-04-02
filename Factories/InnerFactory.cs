namespace DesignPatterns.Factories;

public class InnerFactory
{
    public class Point
    {
        private double x;
        private double y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static Point Origin = new Point(0, 0); // better

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    public static void RunDemo()
    {
        var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);

        Console.WriteLine(point);

        var origin = Point.Origin;

        Console.WriteLine(origin);
    }
}
