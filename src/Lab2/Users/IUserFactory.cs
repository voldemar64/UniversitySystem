namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public interface IUserFactory
{
    IUser CreateUser(string name);
}