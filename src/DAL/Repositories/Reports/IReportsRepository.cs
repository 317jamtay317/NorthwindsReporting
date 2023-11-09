using System.Data;
using DAL.Connection;
using DAL.Repositories.Base;
using Dapper;
using Models;

namespace DAL.Repositories.Reports;

public interface IReportsRepository : IRepository<Report>
{
    /// <summary>
    /// Creates a new report in the database
    /// </summary>
    public Task<bool> Create(Report report);

    /// <summary>
    /// Updates the values of the passed report in the database
    /// </summary>
    public Task<bool> Update(Report report);

    /// <summary>
    /// Deletes the associated report in the database
    /// </summary>
    public Task<bool> Delete(int id);
}

internal class ReportRepository : RepositoryBase<Report>, IReportsRepository
{
    public ReportRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    protected override string TableName => "ReportDefinitions";

    public override async Task<Report> GetById(int id)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
        var report = await connection.QuerySingleAsync<Report>(sql, new { Id = id });
        var fields = await connection
            .QueryAsync<ReportField>(
                "SELECT * FROM ReportFields WHERE ReportId = @reportId",
                new { reportId = id });
        report.Fields = fields;
        return report;
    }

    public async Task<bool> Create(Report report)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = $@"INSERT INTO {TableName}(Name, Description, ReportType, QueryId) "
    }

    public Task<bool> Update(Report report)
    {
       throw new RowNotInTableException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}