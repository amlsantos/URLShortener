using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests;

public class PersistenceLayerTests
{
    [Fact]
    public void PersistenceLayer_ShouldNotDependOn_PresentationLayer()
    {
        // arrange
        var persistence = Assembly.GetAssembly(typeof(Persistence.DependencyInjection));
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));

        // act
        var result = Types.InAssembly(persistence)
            .Should()
            .NotHaveDependencyOn(presentation.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void PersistenceLayer_ShouldDependOn_ApplicationLayer()
    {
        // arrange
        var persistence = Assembly.GetAssembly(typeof(Persistence.DependencyInjection));
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        const string concreteImplementations = "Repository, DbContext, UnitOfWork";
        
        // act
        var result = Types.InAssembly(persistence)
            .That()
            .HaveNameEndingWith(concreteImplementations)
            .Should()
            .HaveDependencyOn(application.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void PersistenceLayer_ShouldDependOn_DomainLayer()
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
}