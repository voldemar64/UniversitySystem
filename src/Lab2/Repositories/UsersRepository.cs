using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class UsersRepository : IRepository<IUser>
{
    private readonly Dictionary<Guid, IUser> _storage = new Dictionary<Guid, IUser>();

    public void Add(IUser item)
    {
        if (_storage.ContainsKey(item.Id))
        {
            throw new ArgumentException("Юзер уже добавлен");
        }

        _storage.Add(item.Id, item);
    }

    public bool Remove(Guid id)
    {
        return _storage.Remove(id);
    }

    public IUser? GetById(Guid id)
    {
        _storage.TryGetValue(id, out IUser? user);
        return user;
    }

    public IEnumerable<IUser> GetAll()
    {
        return _storage.Values;
    }

    public void Clear()
    {
        _storage.Clear();
    }

    public void Update(IUser item)
    {
        _storage[item.Id] = item;
    }
}