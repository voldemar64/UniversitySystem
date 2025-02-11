using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.ContentCreation;

public interface IContentFactory
{
    Lection CreateLection(string name, string description, string content, IUser author);

    Labwork CreateLabwork(string name, string description, string criteria, int score, IUser author);
}