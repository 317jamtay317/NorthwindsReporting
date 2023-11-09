using DAL.Connection;
using DAL.Repositories.Base;
using Dapper;
using Models;

namespace DAL.Repositories.StoredQueries
{
    internal class StoredQueryRepository : RepositoryBase<StoredQuery>, IStoredQueryRepository
    {
        public StoredQueryRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        protected override string TableName => "StoredQueries";


        public async Task<bool> Create(StoredQuery storedQuery)
        {
            using var connection = await ConnectionFactory.CreateAsync();
            var sql = @$"INSERT INTO {TableName}(Name, Sql)
                        VALUES (@Name, @Sql);
                        SELECT last_insert_rowid();";
            storedQuery.Id = await connection.QuerySingleAsync<int>(sql, storedQuery);

            return storedQuery.Id > 0;
        }

        public async Task<bool> Update(StoredQuery storedQuery)
        {
            using var connection = await ConnectionFactory.CreateAsync();
            var sql = @$"Update {TableName}
                        SET Sql = @Sql, Name = @Name
                        WHERE Id = @Id";
            var result = await connection.ExecuteAsync(sql, storedQuery);
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            using var connection = await ConnectionFactory.CreateAsync();
            var sql = $@"DELETE FROM {TableName} WHERE Id = @Id";
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
