using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace UnitTests;

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
}