using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubject
{
    bool HasRightsToEdit(IUser user);

    Result Edit(
        string? name,
        IReadOnlyCollection<Lection>? lections,
        IUser? user,
        int? passScore);
}