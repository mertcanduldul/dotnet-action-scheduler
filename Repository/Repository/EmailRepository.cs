using System.Data;
using Core.Model;
using Core.Repository;
using Dapper;

namespace Repository.Repository;

public class EmailRepository : BaseRepository, IEmailRepository

{
    public async Task<CN_EMAIL_QUEUE> GetAsync(int id)
    {
        using (IDbConnection dbConnection = _connection)
        {
            string query = @"SELECT * FROM CN_EMAIL_QUEUE WHERE ID_EMAIL_QUEUE = @Id";
            var result = await _connection.QueryAsync<CN_EMAIL_QUEUE>(query, new { @Id = id });
            return result.First();
        }
    }

    public async Task<IEnumerable<CN_EMAIL_QUEUE>> GetAllAsync()
    {
        using (IDbConnection dbConnection = _connection)
        {
            string query = @$"SELECT * FROM CN_EMAIL_QUEUE (NOLOCK)";
            var result = await _connection.QueryAsync<CN_EMAIL_QUEUE>(query);
            return result;
        }
    }

    public async Task<int> AddAsync(CN_EMAIL_QUEUE entity)
    {
        using (IDbConnection dbConnection = _connection)
        {
            string query = @$"INSERT INTO CN_EMAIL_QUEUE 
                              (EMAIL_FROM, EMAIL_TO, EMAIL_CC, EMAIL_BCC, EMAIL_SUBJECT, EMAIL_BODY, EMAIL_DATE, EMAIL_STATUS)
                              VALUES (@EMAIL_FROM, @EMAIL_TO, @EMAIL_CC, @EMAIL_BCC, @EMAIL_SUBJECT, @EMAIL_BODY, @EMAIL_DATE, @EMAIL_STATUS)";
            var result = await _connection.ExecuteScalarAsync<int>(query, new
            {
                @EMAIL_FROM = "sistem@mertcanduldul.com",
                @EMAIL_TO = entity.EMAIL_TO,
                @EMAIL_CC = entity.EMAIL_CC,
                @EMAIL_BCC = entity.EMAIL_BCC,
                @EMAIL_SUBJECT = entity.EMAIL_SUBJECT,
                @EMAIL_BODY = entity.EMAIL_BODY,
                @EMAIL_DATE = DateTime.Now,
                @EMAIL_STATUS = 0
            });
            return result;
        }
    }

    public async Task<CN_EMAIL_QUEUE> Update()
    {
        using (IDbConnection dbConnection = _connection)
        {
            string query = @$"UPDATE CN_EMAIL_QUEUE 
                              SET EMAIL_STATUS = @EMAIL_STATUS";
            var result = await _connection.ExecuteScalarAsync<CN_EMAIL_QUEUE>(query, new
            {
                @EMAIL_STATUS = 1
            });

            return result;
        }
    }

    public async Task<IEnumerable<string>> GetEmailByFromMail()
    {
        using (IDbConnection dbConnection = _connection)
        {
            string query = @$"SELECT DISTINCT EMAIL_FROM FROM CN_EMAIL_QUEUE (NOLOCK)";
            var result = await _connection.QueryAsync<string>(query);
            return result;
        }
    }
}