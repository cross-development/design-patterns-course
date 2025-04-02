namespace DesignPatterns.Factories;

public class AsynchronousFactoryMethod
{
    public class Foo
    {
        private Foo()
        {
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    public static async Task RunDemo()
    {
        // Is not the best option
        // var foo = new Foo();
        // await foo.InitAsync();

        Foo x = await Foo.CreateAsync();

        Console.WriteLine(x);
    }
}
