using Itmo.ObjectOrientedProgramming.Lab2.Lections;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LectionsRepository : IRepository<Lection>
{
    private readonly Dictionary<Guid, Lection> _storage = new Dictionary<Guid, Lection>();

    public void Add(Lection item)
    {
        if (_storage.ContainsKey(item.Id))
        {
            throw new ArgumentException("Лекция уже добавлена");
        }

        _storage.Add(item.Id, item);
    }

    public bool Remove(Guid id)
    {
        return _storage.Remove(id);
    }

    public Lection? GetById(Guid id)
    {
        _storage.TryGetValue(id, out Lection? lection);
        return lection;
    }

    public IEnumerable<Lection> GetAll()
    {
        return _storage.Values;
    }

    public void Clear()
    {
        _storage.Clear();
    }

    public void Update(Lection item)
    {
        _storage[item.Id] = item;
    }
}