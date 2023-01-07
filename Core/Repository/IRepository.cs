using System.Linq.Expressions;

namespace Core.Repository;

public interface IRepository<T>
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> AddAsync(T entity);
    Task<T> Update();
}