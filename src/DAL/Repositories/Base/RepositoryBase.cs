using DAL.Connection;
using Dapper;

namespace DAL.Repositories.Base;

internal abstract class RepositoryBase{}

internal abstract class RepositoryBase<T> : RepositoryBase, IRepository<T>
    where T : class
{
    protected IConnectionFactory ConnectionFactory { get; }

    protected RepositoryBase(IConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }
    protected abstract string TableName { get; }

    public virtual async Task<T> GetById(int id)
    {
        var sql = $"SELECT * FROM {TableName} WHERE Id = @id";
        using var connection = await ConnectionFactory.CreateAsync();
        var model = await connection.QuerySingleAsync<T>(sql, new { id });
        return model;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        var sql = $"SELECT * FROM {TableName}";
        using var connection = await ConnectionFactory.CreateAsync();
        var items = await connection.QueryAsync<T>(sql);
        return items;
    }

    public virtual async Task<int> Count()
    {
        var sql = $"SELECT Count(*) FROM {TableName}";
        using var connection = await ConnectionFactory.CreateAsync();
        var count = await connection.QuerySingleAsync<int>(sql);
        return count;
    }
}