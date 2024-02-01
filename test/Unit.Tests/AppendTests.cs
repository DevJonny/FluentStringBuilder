namespace Unit.Tests;

public class AppendTests
{
    [Fact]
    public void Append_BuildWithNoAppend_ReturnsEmptyString()
    {
        // arrange
        var stringBuilder = new FluentStringBuilder();
        
        // act
        var builtString = stringBuilder.Build();
        
        // assert
        builtString.Should().Be(string.Empty);
    }
    
    [Fact]
    public void Append_SingleAppend_StringBuilds()
    {
        // arrange / act
        var builtString = new FluentStringBuilder().Append("I am appended").Build();
        
        // assert
        builtString.Should().Be("I am appended");
    }

    [Fact]
    public void Append_MultipleAppend_StringBuilds()
    {
        // arrange / act
        var builtString = new FluentStringBuilder()
            .Append("First String")
            .Append(" ")
            .Append("Second String")
            .Build();

        // assert
        builtString.Should().Be("First String Second String");
    }
}