using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace UnitTests;

public class DomainLayerTests
{
    [Fact]
    public void DomainLayer_ShouldNotDependOn_ApplicationLayer()
    {
        // arrange
        var domain = Assembly.GetAssembly(typeof(Domain.DependencyInjection));
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));

        // act
        var result = Types.InAssembly(domain)
            .Should()
            .NotHaveDependencyOn(application.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void DomainLayer_ShouldNotDependOn_PersistenceLayer()
    {
        // arrange
        var domain = Assembly.GetAssembly(typeof(Domain.DependencyInjection));
        var persistence = Assembly.GetAssembly(typeof(Persistence.DependencyInjection));

        // act
        var result = Types.InAssembly(domain)
            .Should()
            .NotHaveDependencyOn(persistence.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void DomainLayer_ShouldNotDependOn_InfrastructureLayer()
    {
        // arrange
        var domain = Assembly.GetAssembly(typeof(Domain.DependencyInjection));
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));

        // act
        var result = Types.InAssembly(domain)
            .Should()
            .NotHaveDependencyOn(infrastructure.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void DomainLayer_ShouldNotDependOn_PresentationLayer()
    {
        // arrange
        var domain = Assembly.GetAssembly(typeof(Domain.DependencyInjection));
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));

        // act
        var result = Types.InAssembly(domain)
            .Should()
            .NotHaveDependencyOn(presentation.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
}