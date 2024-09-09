using System;
namespace EventHub;

using Dapper;
using MySql.Data.MySqlClient;

public class DataService (string connectionString)
{
    private readonly string connectionString = connectionString;

    // LoadData - retrieving data from the database
    public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            var rows = await connection.QueryAsync<T>(sql, parameters);
            return rows.ToList();
        }
    }

    // SaveData - saving or manipulating data in the database
    public async Task SaveData<U>(string sql, U parameters)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }    
}
