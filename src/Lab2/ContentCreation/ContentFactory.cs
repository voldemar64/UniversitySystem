using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.ContentCreation;

public class ContentFactory : IContentFactory
{
    public Lection CreateLection(string name, string description, string content, IUser author)
    {
        return new Lection(name, description, content, author);
    }

    public Labwork CreateLabwork(string name, string description, string criteria, int score, IUser author)
    {
        return new Labwork(name, description, criteria, score, author);
    }
}