namespace Fluent.StringBuilder;

public interface IAmAnAppender
{
    public IHasACondition Append(string stringToAppend);
}

public interface IHasACondition : IBuild
{
    public ICondition If();
}

public interface ICondition
{
    public IBuild NotNullOrEmpty();

    public IBuild NotNullOrWhitespace();
}

public interface IBuild : IAmAnAppender
{
    public string Build();
}