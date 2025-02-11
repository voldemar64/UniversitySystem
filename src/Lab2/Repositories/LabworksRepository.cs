using Itmo.ObjectOrientedProgramming.Lab2.Labworks;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class LabworksRepository : IRepository<Labwork>
{
    private readonly Dictionary<Guid, Labwork> _storage = new Dictionary<Guid, Labwork>();

    public void Add(Labwork item)
    {
        if (_storage.ContainsKey(item.Id))
        {
            throw new ArgumentException("Лабораторная уже добавлена");
        }

        _storage.Add(item.Id, item);
    }

    public bool Remove(Guid id)
    {
        return _storage.Remove(id);
    }

    public Labwork? GetById(Guid id)
    {
        _storage.TryGetValue(id, out Labwork? labwork);
        return labwork;
    }

    public IEnumerable<Labwork> GetAll()
    {
        return _storage.Values;
    }

    public void Clear()
    {
        _storage.Clear();
    }

    public void Update(Labwork item)
    {
        _storage[item.Id] = item;
    }
}