namespace MyLibrary.Repositories;

public interface IRepository<T>
{
    public T? Find();

    public Task<T?> FindAsync();

    public void Save(T instance);

    public Task SaveAsync(T instance);
}
