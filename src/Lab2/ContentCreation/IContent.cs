using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.ContentCreation;

public interface IContent
{
    public bool HasRightsToEdit(IUser user);

    public Result Edit(
        string? name = null,
        string? description = null,
        string? content = null,
        IUser? user = null);
}