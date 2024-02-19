namespace Fluent.StringBuilder;

public class FluentStringBuilder :
    IBuild,
    IAmAnAppender,
    IHaveACondition,
    INegativeCondition,
    ICondition
{
    private readonly System.Text.StringBuilder _stringBuilder;

    private string? _stringToAppend;
    private string? _delimiter;
    private bool invertCondition;

    public INegativeCondition If => this;

    public ICondition Not
    {
        get
        {
            invertCondition = true;
            return this;
        }
    }

    public FluentStringBuilder()
    {
        _stringBuilder = new System.Text.StringBuilder();
    }

    public FluentStringBuilder(string? initialValue = null)
    {
        _stringBuilder = new System.Text.StringBuilder(initialValue);
    }

    public IHaveACondition Append(string? stringToAppend)
    {
        AppendCachedValues();

        _stringToAppend = stringToAppend;

        return this;
    }

    public IHaveACondition Append(string delimiter, string? stringToAppend)
    {
        AppendCachedValues();

        _delimiter = delimiter;
        _stringToAppend = stringToAppend;

        return this;
    }

    public IBuild Null()
        => AppendOnCondition(() => _stringToAppend is null);

    public IBuild NullOrEmpty()
        => AppendOnCondition(() => string.IsNullOrEmpty(_stringToAppend));

    public IBuild NullOrWhitespace()
        => AppendOnCondition(() => string.IsNullOrWhiteSpace(_stringToAppend));

    public string Build()
    {
        if (_stringToAppend is not null)
            _stringBuilder.Append(_stringToAppend);

        return _stringBuilder.ToString();
    }

    private FluentStringBuilder AppendOnCondition(Func<bool> predicate)
    {
        if (invertCondition && predicate.Invoke())
        {
            _stringToAppend = null;
            _delimiter = null;
            return this;
        }

        if (_delimiter is not null)
            _stringBuilder.Append(_delimiter);

        _stringBuilder.Append(_stringToAppend);

        _delimiter = null;
        _stringToAppend = null;

        return this;
    }

    private void AppendCachedValues()
    {
        if (_delimiter is not null)
            _stringBuilder.Append(_delimiter);

        if (_stringToAppend is not null)
            _stringBuilder.Append(_stringToAppend);
    }
}