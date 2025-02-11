using Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class EducationProgramRepository : IRepository<EducationProgram>
{
    private readonly Dictionary<Guid, EducationProgram> _storage = new Dictionary<Guid, EducationProgram>();

    public void Add(EducationProgram item)
    {
        _storage.Add(item.Id, item);
    }

    public bool Remove(Guid id)
    {
        return _storage.Remove(id);
    }

    public EducationProgram? GetById(Guid id)
    {
        _storage.TryGetValue(id, out EducationProgram? educationProgram);
        return educationProgram;
    }

    public IEnumerable<EducationProgram> GetAll()
    {
        return _storage.Values;
    }

    public void Clear()
    {
        _storage.Clear();
    }

    public void Update(EducationProgram item)
    {
        _storage[item.Id] = item;
    }
}