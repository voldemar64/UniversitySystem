using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectsBuilders;

public interface IExamScoreBuilder
{
    IExamScoreBuilder WithExamScore(int examScore);

    IExamScoreBuilder WithPassScore(int passScore);

    ISubject Build();
}

public interface IAuthorBuilder
{
    IIsExamBuilder WithAuthor(IUser author);
}

public interface IIsExamBuilder
{
    INameBuilder WithIsExam(bool isExam);
}

public interface INameBuilder
{
    ILabworksBuilder WithName(string name);
}

public interface ILabworksBuilder
{
    ILectionsBuilder WithLabworks(IEnumerable<Labwork> labworks);
}

public interface ILectionsBuilder
{
    IExamScoreBuilder WithLections(IEnumerable<Lection> lections);
}