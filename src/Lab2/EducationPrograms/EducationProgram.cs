using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public class EducationProgram
{
    public Guid Id { get; }

    public string Name { get; }

    public string Admin { get; }

    public IReadOnlyCollection<ISubject> Subjects { get; }

    public EducationProgram(string name, string admin, IReadOnlyCollection<ISubject> subjects)
    {
        Id = Guid.NewGuid();
        Name = name;
        Admin = admin;
        Subjects = subjects;
    }
}