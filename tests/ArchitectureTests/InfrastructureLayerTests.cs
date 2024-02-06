using System.Reflection;
using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests;

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
    public void InfrastructureLayer_ShouldNotDependOn_DomainLayer()
    {
        // arrange
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));
        var domain = Assembly.GetAssembly(typeof(Domain.DependencyInjection));

        // act
        var result = Types.InAssembly(infrastructure)
            .Should()
            .NotHaveDependencyOn(domain.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureLayer_ShouldDependOn_ApplicationLayer()
    {
        // arrange
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        const string options = "Options";
        
        // act
        var result = Types.InAssembly(infrastructure)
            .That()
            .DoNotHaveNameEndingWith(options)
            .Should()
            .HaveDependencyOn(application.GetName().Name)
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
    
    [Fact]
    public void Behaviours_ShouldBe_Sealed()
    {
        // arrange
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));
        
        // act
        var result = Types.InAssembly(infrastructure)
            .That()
            .ImplementInterface(typeof(IPipelineBehavior<,>))
            .Should()
            .BeSealed()
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
}