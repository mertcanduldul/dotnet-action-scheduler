using System.Linq.Expressions;

namespace Core.Service;

public interface IService<T> where T : class
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task Update(T entity);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
}