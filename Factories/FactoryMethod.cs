namespace DesignPatterns.Factories;

public class FactoryMethod
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar,
    }

    public class Point
    {
        private double x;
        private double y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        // factory method
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    public static void RunDemo()
    {
        var point = Point.NewPolarPoint(1.0, Math.PI / 2);

        Console.WriteLine(point);
    }
}
