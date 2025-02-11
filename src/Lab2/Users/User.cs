namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    public Guid Id { get; private set; }

    public string Name { get; }

    public void SetId()
    {
        if (Id == Guid.Empty)
        {
            Id = Guid.NewGuid();
        }
    }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}