using DAL.Connection;
using Dapper;

namespace DAL.Database
{
    internal class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IConnectionFactory _connectionFactory;

        public DatabaseInitializer(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task Init()
        {
            var reportsTable = @"
                        CREATE TABLE IF NOT EXISTS ReportDefinitions (
                            Id INTEGER PRIMARY KEY,
                            Name TEXT NOT NULL,
                            Description TEXT,
                            ReportType INT NOT NULL,
                            Query TEXT NOT NULL
                        );";
            var fieldsTable = @"
                CREATE TABLE IF NOT EXISTS ReportFields (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                ReportDefinitionId INTEGER NOT NULL,
                FOREIGN KEY (ReportDefinitionId) REFERENCES ReportDefinitations (Id)
                );
            ";
            using var connection = await _connectionFactory.CreateAsync();
            var transaction = connection.BeginTransaction();
            try
            {
                await connection.ExecuteAsync(reportsTable, transaction);
                await connection.ExecuteAsync(fieldsTable, transaction);
                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                transaction.Rollback();
                throw;
            }

        }
    }
}
