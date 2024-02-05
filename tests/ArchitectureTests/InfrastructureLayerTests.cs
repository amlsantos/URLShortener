using System.Reflection;
using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Xunit;

namespace UnitTests;

public class InfrastructureLayerTests
{
    [Fact]
    public void InfrastructureLayer_ShouldNotDependOn_PresentationLayer()
    {
        // arrange
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));

        // act
        var result = Types.InAssembly(infrastructure)
            .Should()
            .NotHaveDependencyOn(presentation.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Behaviours_ShouldHaveNamingEndingWith_Behaviour()
    {
        // arrange
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));
        const string expectedName = "Behavior";
        
        // act
        var result = Types.InAssembly(infrastructure)
            .That()
            .ImplementInterface(typeof(IPipelineBehavior<,>))
            .Should()
            .HaveNameMatching(expectedName)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
}