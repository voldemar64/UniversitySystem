using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class Subject : ISubject, IPrototype<ISubject>
{
    public static IAuthorBuilder Builder => new SubjectBuilder();

    public Guid Id { get; }

    public string Name { get; private set; }

    public IUser Author { get; }

    public bool IsExam { get; }

    public IReadOnlyCollection<Labwork> Labworks { get; }

    public IReadOnlyCollection<Lection> Lections { get; private set; }

    public int ExamScore { get; }

    public int? PassScore { get; private set; }

    public Guid? ParentId { get; }

    private class SubjectBuilder : IAuthorBuilder, IIsExamBuilder, INameBuilder, ILabworksBuilder, ILectionsBuilder, IExamScoreBuilder
    {
        public string? NewName { get; private set; }

        public IUser? NewAuthor { get; private set; }

        public bool NewIsExam { get; private set; }

        public IReadOnlyCollection<Labwork>? NewLabworks { get; private set; }

        public IReadOnlyCollection<Lection>? NewLections { get; private set; }

        public int NewExamScore { get; private set; }

        public int? NewPassScore { get; private set; }

        public IIsExamBuilder WithAuthor(IUser author)
        {
            NewAuthor = author;
            return this;
        }

        public INameBuilder WithIsExam(bool isExam)
        {
            NewIsExam = isExam;
            return this;
        }

        public ILabworksBuilder WithName(string name)
        {
            NewName = name;
            return this;
        }

        public ILectionsBuilder WithLabworks(IEnumerable<Labwork> labworks)
        {
            NewLabworks = labworks.ToList();
            return this;
        }

        public IExamScoreBuilder WithLections(IEnumerable<Lection> lections)
        {
            NewLections = lections.ToList();
            return this;
        }

        public IExamScoreBuilder WithExamScore(int examScore)
        {
            NewExamScore = examScore;

            return this;
        }

        public IExamScoreBuilder WithPassScore(int passScore)
        {
            NewPassScore = passScore;
            return this;
        }

        public ISubject Build()
        {
            TrowIfNullValue(NewName, NewLabworks, NewLections, NewAuthor);

            return new Subject(NewName, NewIsExam, NewExamScore, NewLabworks, NewLections, NewAuthor, NewPassScore);
        }

        private void TrowIfNullValue(
            [NotNull] string? newName,
            [NotNull] IReadOnlyCollection<Labwork>? newLabworks,
            [NotNull] IReadOnlyCollection<Lection>? newLections,
            [NotNull] IUser? newAuthor)
        {
            ArgumentNullException.ThrowIfNull(newName);

            ArgumentNullException.ThrowIfNull(newLabworks);

            ArgumentNullException.ThrowIfNull(newLections);

            ArgumentNullException.ThrowIfNull(newLections);

            ArgumentNullException.ThrowIfNull(newAuthor);
        }
    }

    public Subject(
        string name,
        bool isExam,
        int examScore,
        IReadOnlyCollection<Labwork> labworks,
        IReadOnlyCollection<Lection> lections,
        IUser author,
        int? passScore = null,
        Guid? parentId = null)
    {
        var labworksList = labworks.ToList();
        int totalScore = ValidateScore(labworksList);

        if (totalScore != 100)
        {
            throw new InvalidOperationException("Subject total score should be 100.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Labworks = labworks;
        Lections = lections;
        Author = author;
        IsExam = isExam;
        ExamScore = examScore;
        PassScore = passScore ?? PassScore;
        ParentId = parentId ?? ParentId;
    }

    public bool HasRightsToEdit(IUser user)
    {
        return user.Id == Author.Id;
    }

    public Result Edit(
        string? name = null,
        IReadOnlyCollection<Lection>? lections = null,
        IUser? user = null,
        int? passScore = null)
    {
        if (user != null && !HasRightsToEdit(user))
        {
            return new Result.WrongAuthor();
        }

        Name = name ?? Name;
        Lections = lections ?? Lections;
        PassScore = passScore ?? PassScore;

        return new Result.Success();
    }

    public ISubject Clone()
    {
        return new Subject(Name, IsExam, ExamScore, Labworks, Lections, Author, PassScore, Id);
    }

    private int ValidateScore(List<Labwork> labworksList)
    {
        int totalScore = 0;

        foreach (Labwork lab in labworksList)
        {
            totalScore += lab.Score;
        }

        totalScore += ExamScore;

        return totalScore;
    }
}