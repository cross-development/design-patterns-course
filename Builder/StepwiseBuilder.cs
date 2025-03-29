namespace DesignPatterns.Builder;

public enum CarType
{
    Sedan,
    Crossover,
}

public class Car
{
    public CarType Type { get; set; }
    public int WheelSize { get; set; }
}

public interface ISpecifyCarType
{
    public ISpecifyWheelSize OfType(CarType type);
}

public interface ISpecifyWheelSize
{
    public IBuildCar WithWheels(int size);
}

public interface IBuildCar
{
    public Car Build();
}


public class CarBuilder
{
    private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
    {
        private Car car = new();

        public ISpecifyWheelSize OfType(CarType type)
        {
            car.Type = type;
            return this;
        }

        public IBuildCar WithWheels(int size)
        {
            switch (car.Type)
            {
                case CarType.Crossover when size < 17 || size > 20:
                case CarType.Sedan when size < 15 || size > 17:
                    throw new ArgumentException($"Wrong size of wheel for {car.Type}");
            }

            car.WheelSize = size;
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }

    public static ISpecifyCarType Create()
    {
        return new Impl();
    }
}

public class StepwiseBuilder
{
    public static void RunDemo()
    {
        var car = CarBuilder.Create() // ISpecifyCarType
        .OfType(CarType.Crossover) // ISpecifyWheelSize
        .WithWheels(18) // IBuildCar
        .Build(); // Car

        Console.WriteLine(car);
    }
}
