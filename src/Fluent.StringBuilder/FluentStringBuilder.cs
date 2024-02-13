namespace Fluent.StringBuilder;

public class FluentStringBuilder : IBuild, IAmAnAppender, IHasACondition, ICondition
{
    private readonly System.Text.StringBuilder _stringBuilder;

    private string? _stringToAppend;

    public FluentStringBuilder()
    {
        _stringBuilder = new System.Text.StringBuilder();
    }

    public FluentStringBuilder(string? initialValue = null)
    {
        _stringBuilder = new System.Text.StringBuilder(initialValue);
    }
    
    public IHasACondition Append(string? stringToAppend)
    {
        if (_stringToAppend is not null)
            _stringBuilder.Append(_stringToAppend);
        
        _stringToAppend = stringToAppend;

        return this;
    }

    public ICondition If() => this;

    public IBuild NotNull()
        => AppendOnCondition(() => _stringToAppend is not null);
    
    public IBuild NotNullOrEmpty()
        => AppendOnCondition(() => string.IsNullOrEmpty(_stringToAppend));

    public IBuild NotNullOrWhitespace()
        => AppendOnCondition(() => string.IsNullOrWhiteSpace(_stringToAppend));

    private FluentStringBuilder AppendOnCondition(Func<bool> predicate)
    {
        if (predicate.Invoke())
        {
            _stringToAppend = null;
            return this;
        }

        _stringBuilder.Append(_stringToAppend);
        _stringToAppend = null;

        return this;
    }
    
    public string Build()
    {
        if (_stringToAppend is not null)
            _stringBuilder.Append(_stringToAppend);

        return _stringBuilder.ToString();
    }
}