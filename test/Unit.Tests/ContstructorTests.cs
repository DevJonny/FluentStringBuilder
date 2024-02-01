namespace Unit.Tests;

public class ConstructorTests
{
    [Fact]
    public void Ctor_Default_ReturnsEmptyString()
    {
        new FluentStringBuilder().Build().Should().BeEmpty();
    }

    [Fact]
    public void Ctor_WithInitialValue_ReturnsEmptyString()
    {
        // arrange
        const string initialString = "I am initial";
        
        // act / assert
        new FluentStringBuilder(initialString).Build().Should().Be(initialString);
    }
}