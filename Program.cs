using DesignPatterns.Solid;
using DesignPatterns.Builder;
using DesignPatterns.Factories;
using DesignPatterns.Prototype;

namespace DesignPatterns;

public class Program
{
    static void Main(string[] args)
    {
        // SOLID
        SingleResponsibilityPrinciple.RunDemo();
        OpenClosedPrinciple.RunDemo();
        LiskovSubstitutionPrinciple.RunDemo();
        InterfaceSegregationPrinciple.RunDemo();
        DependencyInversionPrinciple.RunDemo();

        // DESIGN PATTERNS
        // Builder
        LifeWithoutBuilder.RunDemo();
        HtmlBuilderDemo.RunDemo();
        FluentBuilder.RunDemo();
        StepwiseBuilder.RunDemo();
        FunctionalBuilder.RunDemo();
        FacetedBuilder.RunDemo();

        // Factories
        PointExample.RunDemo();
        FactoryMethod.RunDemo();
        AsynchronousFactoryMethod.RunDemo();
        Factory.RunDemo();
        ObjectTracking.RunDemo();
        InnerFactory.RunDemo();
        AbstractFactory.RunDemo();
        AbstractFactoryOcp.RunDemo();

        // Prototype
        ICloneableIsBad.RunDemo();
        CopyConstructors.RunDemo();
        ExplicitDeepCope.RunDemo();
        PrototypeInheritance.RunDemo();
        CopyThroughSerialization.RunDemo();
    }
}
