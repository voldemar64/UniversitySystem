using Itmo.ObjectOrientedProgramming.Lab2.ContentCreation;
using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labworks;

public class Labwork : IContent, IPrototype<Labwork>
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Сriteria { get; private set; }

    public int Score { get; }

    public IUser Author { get; }

    public Guid? ParentId { get; }

    public Labwork(
        string name,
        string description,
        string сriteria,
        int score,
        IUser author,
        Guid? parentId = null)
    {
        if (score <= 0)
        {
            throw new InvalidOperationException("Score should be more than 0.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Сriteria = сriteria;
        Score = score;
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
        Сriteria = content ?? Сriteria;

        return new Result.Success();
    }

    public Labwork Clone()
    {
        return new Labwork(Name, Description, Сriteria, Score, Author, Id);
    }
}