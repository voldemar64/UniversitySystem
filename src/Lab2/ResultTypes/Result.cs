namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record Result
{
    protected Result() { }

    public sealed record Success() : Result;

    public abstract record Failure : Result
    {
        public abstract string ErrorMessage { get; }
    }

    public sealed record WrongAuthor : Failure
    {
        public override string ErrorMessage => "You don't have rights to edit.";
    }
}