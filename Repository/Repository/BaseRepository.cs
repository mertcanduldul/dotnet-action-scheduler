using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Repository.Repository;

public class BaseRepository
{
    internal readonly string _connectionString;

    internal IDbConnection _connection
    {
        get { return new SqlConnection(_connectionString); }
    }

    public static string GetConnectionStringsValue(string key)
    {
        return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")[key];
    }

    public BaseRepository()
    {
        SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(GetConnectionStringsValue("DbConnectionString"));
        var DbPassword = GetConnectionStringsValue("DbPassword");
        builder.Password = DbPassword;
        _connectionString = builder.ConnectionString;
    }
}