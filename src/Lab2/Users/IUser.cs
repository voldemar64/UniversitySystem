namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public interface IUser
{
    Guid Id { get; }

    string Name { get; }
}