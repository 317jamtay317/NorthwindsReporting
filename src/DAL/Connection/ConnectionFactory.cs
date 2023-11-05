using System.Data;
using Microsoft.Data.Sqlite;

namespace DAL.Connection;

internal class ConnectionFactory:IConnectionFactory
{
    public async Task<IDbConnection> CreateAsync()
    {
        //the connection string normally would be in appsettings and configurable 
        var connection = new SqliteConnection("Data Source=northwind.db;Version=3;");
        await connection.OpenAsync();
        return connection;
    }
}