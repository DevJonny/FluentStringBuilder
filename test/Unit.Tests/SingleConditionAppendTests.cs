namespace Unit.Tests;

public class SingleConditionAppendTests
{
    [Fact]
    public void AppendIfNotNullOrEmpty_SingleAppend_StringBuilds()
    {
        const string expectedString = "I will be appended";
        
        // act
        new FluentStringBuilder()
            .Append(expectedString).If.Not.NullOrEmpty()
            .Build()
            .Should().Be(expectedString);
    }
    
    [Theory]
    [InlineData(" ")]
    [InlineData(",")]
    [InlineData(".")]
    public void AppendWithDelimiterIfNotNullOrEmpty_SingleAppend_StringBuilds(string delimiter)
    {
        const string expectedString = "I will be appended";
        
        // act
        new FluentStringBuilder()
            .Append(delimiter, expectedString).If.Not.NullOrEmpty()
            .Build()
            .Should().Be($"{delimiter}{expectedString}");
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
            .Append(appendedString!).If.Not.NullOrEmpty()
            .Build()
            .Should().Be(expectedString);
    }
    
    [Theory]
    [InlineData(".", null, "")]
    [InlineData(".", "", "")]
    [InlineData(" ", null, "")]
    [InlineData(" ", "", "")]
    [InlineData(",", null, "")]
    [InlineData(",", "", "")]
    public void AppendWithDelimiterIfNotNullOrEmpty_SingleAppend_StringIsEmpty(
        string delimiter,
        string? appendedString,
        string? expectedString)
    {
        // act / assert
        new FluentStringBuilder()
            .Append(delimiter, appendedString!).If.Not.NullOrEmpty()
            .Build()
            .Should().Be($"{expectedString}");
    }
    
    [Fact]
    public void AppendIfNotNullOrWhitespace_SingleAppend_StringIsEmpty()
    {
        // act / assert
        new FluentStringBuilder()
            .Append(" ").If.Not.NullOrWhitespace()
            .Build()
            .Should().Be(string.Empty);
    }

    [Fact]
    public void AppendIfNotNull_SingleAppend_StringIsEmpty()
    {
        // act / assert
        new FluentStringBuilder()
            .Append(null).If.Not.Null()
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
            .Append(input).If.Not.Null()
            .Build()
            .Should().Be(input);
    }

    [Theory]
    [InlineData(" ","")]
    [InlineData(" "," ")]
    [InlineData(".","")]
    [InlineData("."," ")]
    [InlineData(",","")]
    [InlineData(","," ")]
    public void AppendWithDelimiterIfNotNull_SingleAppend_StringIsNotEmpty(
        string delimiter,
        string input)
    {
        // act / assert
        new FluentStringBuilder()
            .Append(delimiter, input).If.Not.Null()
            .Build()
            .Should().Be($"{delimiter}{input}");
    }
}