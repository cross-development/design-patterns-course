using DesignPatterns.Solid;
using DesignPatterns.Builder;

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

        // Builder
        LifeWithoutBuilder.RunDemo();
        HtmlBuilderDemo.RunDemo();
        FluentBuilder.RunDemo();
        StepwiseBuilder.RunDemo();
        FunctionalBuilder.RunDemo();
        FacetedBuilder.RunDemo();
    }
}
