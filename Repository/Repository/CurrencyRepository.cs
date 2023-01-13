using System.Data;
using Core.Model;
using Core.Repository;
using Dapper;

namespace Repository.Repository;

public class CurrencyRepository : BaseRepository, ICurrencyRepository
{
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
        using (IDbConnection dbconnection = _connection)
        {
            string query =
                $@"INSERT INTO GN_CURRENCY (CURRENCY_NAME,CURRENCY_CODE,CURRENCY_VALUE) VALUES (@CURRENCY_NAME,@CURRENCY_CODE,@CURRENCY_VALUE)";
            var result = await dbconnection.ExecuteScalarAsync<int>(query, entity);
            return result;
        }
    }

    public Task<GN_CURRENCY> Update()
    {
        throw new NotImplementedException();
    }
}