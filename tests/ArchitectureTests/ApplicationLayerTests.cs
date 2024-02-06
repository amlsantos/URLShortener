using System.Reflection;
using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests;

public class ApplicationLayerTests
{
    [Fact]
    public void ApplicationLayer_ShouldNotDependOn_PresentationLayer()
    {
        // arrange
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));

        // act
        var result = Types.InAssembly(application)
            .Should()
            .NotHaveDependencyOn(presentation.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotDependOn_InfrastructureLayer()
    {
        // arrange
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));

        // act
        var result = Types.InAssembly(application)
            .Should()
            .NotHaveDependencyOn(infrastructure.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Behaviours_ShouldHaveNamingEndingWith_Behaviour()
    {
        // arrange
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        const string expectedName = "Behaviour";
        
        // act
        var result = Types.InAssembly(application)
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
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        
        // act
        var result = Types.InAssembly(application)
            .That()
            .ImplementInterface(typeof(IPipelineBehavior<,>))
            .Should()
            .BeSealed()
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Handlers_ShouldHaveNamingEndingWith_Handler()
    {
        // arrange
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        const string expectedName = "Handler";
        
        // act
        var result = Types.InAssembly(application)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should()
            .HaveNameMatching(expectedName)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Services_ShouldBe_Sealed()
    {
        // arrange
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        const string servicesNamespace = "Services";

        // act
        var result = Types.InAssembly(application)
            .That()
            .AreClasses()
            .And()
            .ResideInNamespace(servicesNamespace)
            .Should()
            .BeSealed()
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
}