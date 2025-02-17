namespace DesignPatterns.Solid;

public class Document
{

}

public interface IMachine
{
    void Print(Document document);
    void Scan(Document document);
    void Fax(Document document);
}

public class MultiFunctionPrinter : IMachine
{
    public void Fax(Document document)
    {
        // some logic
    }

    public void Print(Document document)
    {
        // some logic
    }

    public void Scan(Document document)
    {
        // some logic
    }
}


// Incorrect approach
public class OldFashionedPrinter : IMachine
{
    public void Fax(Document document)
    {
        throw new NotImplementedException();
    }

    public void Print(Document document)
    {
        // some logic
    }

    public void Scan(Document document)
    {
        throw new NotImplementedException();
    }
}

public interface IPrinter
{
    void Print(Document document);
}

public interface IScanner
{
    void Scan(Document document);
}

// Correct approach
public class Photocopier : IPrinter, IScanner
{
    public void Print(Document document)
    {
        // some logic
    }

    public void Scan(Document document)
    {
        // some logic
    }
}

public interface IMultiFunctionDevice : IPrinter, IScanner  //...
{

}

public class MultiFunctionMachine : IMultiFunctionDevice
{
    private IPrinter printer;
    private IScanner scanner;

    public MultiFunctionMachine(IPrinter printer, IScanner scanner)
    {
        this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
        this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
    }

    public void Print(Document document)
    {
        printer.Print(document);
    }

    public void Scan(Document document)
    {
        scanner.Scan(document);
    }
}

public class InterfaceSegregationPrinciple
{
    public static void RunDemo() { }
}
