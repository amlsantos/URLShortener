using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ArchitectureTests;

public class PresentationLayerTests
{
    [Fact]
    public void Controllers_CanNotReference_Infrastructure()
    {
        // arrange
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));
        var infrastructure = Assembly.GetAssembly(typeof(Infrastructure.DependencyInjection));
        const string controller = "Controller";

        // act
        var result = Types.InAssembly(presentation)
            .That()
            .HaveNameEndingWith(controller)
            .ShouldNot()
            .HaveDependencyOn(infrastructure.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Controllers_ShouldReference_Application()
    {
        // arrange
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));
        var application = Assembly.GetAssembly(typeof(Application.DependencyInjection));
        const string controller = "Controller";

        // act
        var result = Types.InAssembly(presentation)
            .That()
            .HaveNameEndingWith(controller)
            .Should()
            .HaveDependencyOn(application.GetName().Name)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DataContracts_ShouldHaveNameEndingWith_RequestOrResponse()
    {
        // arrange
        var presentation = Assembly.GetAssembly(typeof(Presentation.Program));
        const string dataContracts = "Contracts";
        const string requestResponse = "Request, Response";

        // act
        var result = Types.InAssembly(presentation)
            .That()
            .AreClasses()
            .And()
            .ResideInNamespace(dataContracts)
            .Should()
            .HaveNameEndingWith(requestResponse)
            .GetResult();
        
        // assert
        result.IsSuccessful.Should().BeTrue();
    }
}