namespace Unit.Tests;

public class SingleConditionAppendTests
{
    [Fact]
    public void AppendIfNotNullOrEmpty_SingleAppend_StringBuilds()
    {
        const string expectedString = "I will be appended";
        
        // act
        var builtString = new FluentStringBuilder()
            .Append(expectedString).If().NotNullOrEmpty()
            .Build();
        
        // assert
        builtString.Should().Be(expectedString);
    }
    
    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    public void AppendIfNotNullOrEmpty_SingleAppend_StringIsEmpty(
        string? appendedString,
        string? expectedString)
    {
        // act
        var builtString = new FluentStringBuilder()
            .Append(appendedString!).If().NotNullOrEmpty()
            .Build();
        
        // assert
        builtString.Should().Be(expectedString);
    }
    
    [Fact]
    public void AppendIfNotNullOrWhitespace_SingleAppend_StringIsEmpty()
    {
        // act
        var builtString = new FluentStringBuilder()
            .Append(" ").If().NotNullOrWhitespace()
            .Build();
        
        // assert
        builtString.Should().Be(string.Empty);
    }
}