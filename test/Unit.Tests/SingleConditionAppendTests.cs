namespace Unit.Tests;

public class SingleConditionAppendTests
{
    [Fact]
    public void AppendIfNotNullOrEmpty_SingleAppend_StringBuilds()
    {
        const string expectedString = "I will be appended";
        
        // act
        new FluentStringBuilder()
            .Append(expectedString).If().NotNullOrEmpty()
            .Build()
            .Should().Be(expectedString);
    }
    
    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    public void AppendIfNotNullOrEmpty_SingleAppend_StringIsEmpty(
        string? appendedString,
        string? expectedString)
    {
        // act / assert
        new FluentStringBuilder()
            .Append(appendedString!).If().NotNullOrEmpty()
            .Build()
            .Should().Be(expectedString);
    }
    
    [Fact]
    public void AppendIfNotNullOrWhitespace_SingleAppend_StringIsEmpty()
    {
        // act / assert
        new FluentStringBuilder()
            .Append(" ").If().NotNullOrWhitespace()
            .Build()
            .Should().Be(string.Empty);
    }

    [Fact]
    public void AppendIfNotNull_SingleAppend_StringIsEmpty()
    {
        // act / assert
        new FluentStringBuilder()
            .Append(null).If().NotNull()
            .Build()
            .Should().Be(string.Empty);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void AppendIfNotNull_SingleAppend_StringIsNotEmpty(string input)
    {
        // act / assert
        new FluentStringBuilder()
            .Append(input).If().NotNull()
            .Build()
            .Should().BeEmpty(input);
    }
}