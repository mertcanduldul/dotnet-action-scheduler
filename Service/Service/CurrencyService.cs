using System.Linq.Expressions;
using Core.Model;
using Core.Repository;
using Core.Service;

namespace Service.Service;

public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyService(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public Task<GN_CURRENCY> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GN_CURRENCY>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddAsync(GN_CURRENCY entity)
    {
        var result =await _currencyRepository.AddAsync(entity);
        return result;
    }

    public Task Update(GN_CURRENCY entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<GN_CURRENCY> Where(Expression<Func<GN_CURRENCY, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}