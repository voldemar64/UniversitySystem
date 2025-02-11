using Itmo.ObjectOrientedProgramming.Lab2.ContentCreation;
using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public class Lection : IContent, IPrototype<Lection>
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public IUser Author { get; }

    public Guid? ParentId { get; }

    public Lection(
        string name,
        string description,
        string content,
        IUser author,
        Guid? parentId = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Content = content;
        Author = author;
        ParentId = parentId ?? ParentId;
    }

    public bool HasRightsToEdit(IUser user)
    {
        return user.Id == Author.Id;
    }

    public Result Edit(
        string? name = null,
        string? description = null,
        string? content = null,
        IUser? user = null)
    {
        if (user is not null && !HasRightsToEdit(user))
        {
            return new Result.WrongAuthor();
        }

        Name = name ?? Name;
        Description = description ?? Description;
        Content = content ?? Content;

        return new Result.Success();
    }

    public Lection Clone()
    {
        return new Lection(Name, Description, Content, Author, Id);
    }
}