namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class UserFactory : IUserFactory
{
    public IUser CreateUser(string name)
    {
        return new User(name);
    }
}