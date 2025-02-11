namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
{
    void Add(T item);

    bool Remove(Guid id);

    T? GetById(Guid id);

    IEnumerable<T> GetAll();

    public void Clear();

    public void Update(T item);
}