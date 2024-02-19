namespace Fluent.StringBuilder;

public interface IAmAnAppender
{
    public IHaveACondition Append(string stringToAppend);
    public IHaveACondition Append(string delimiter, string stringToAppend);
}

public interface IHaveACondition : IBuild
{
    public INegativeCondition If { get; }
}

public interface INegativeCondition
{
    public ICondition Not { get; }
}

public interface ICondition
{
    public IBuild Null();
    
    public IBuild NullOrEmpty();

    public IBuild NullOrWhitespace();
}

public interface IBuild : IAmAnAppender
{
    public string Build();
}