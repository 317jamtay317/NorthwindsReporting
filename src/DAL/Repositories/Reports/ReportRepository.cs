using System.Data;
using DAL.Connection;
using DAL.Repositories.Base;
using Dapper;
using Models;

namespace DAL.Repositories.Reports;

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
        var sql = $@"INSERT INTO {TableName}(Name, Description, ReportType, QueryId) 
                     VALUES (@Name, @Description, @ReportType, @QueryId); 
                     SELECT last_insert_rowid();";
        var id = await connection.QuerySingleAsync<int>(sql, report);
        report.Id = id;
        return id > 0;
    }

    public async Task<bool> Update(Report report)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = $@"UPDATE {TableName} 
                     SET Name = @Name,
                         Description = @Description,
                         ReportType = @ReportType,
                         QueryId = @QueryId
                     WHERE Id = @Id";
        var result = await connection.ExecuteAsync(sql, report);
        return result > 0;
    }

    public async Task<bool> Delete(int id)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var transaction = connection.BeginTransaction();
        try
        {
            var deleteFieldsSql = "DELETE FROM ReportFields WHERE ReportId = @ReportId";
            var deleteReportSql = $@"DELETE FROM {TableName} WHERE Id = @Id";
            await connection.ExecuteAsync(deleteFieldsSql, new { ReportId = id });
            var reportResult = await connection.ExecuteAsync(deleteReportSql, new { Id = id }, transaction);
            transaction.Commit();
            return reportResult > 0;
        }
        catch
        {
            transaction.Rollback(); 
            throw;
        }
    }

    public async Task<IEnumerable<ReportField>> GetFields(int reportId)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = "SELECT * FROM ReportFields WHERE ReportId = @ReportId";
        var result = await connection.QueryAsync<ReportField>(sql, new { ReportId = reportId });
        return result;
    }

    public async Task<bool> CreateField(int reportId, ReportField field)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = @"INSERT INTO ReportFields(Name, ReportDefinitionId) 
                    VALUES (@Name, @ReportDefinitionId);
                    SELECT last_insert_rowid();";
        field.ReportDefinitionId = reportId;
        var id = await connection.QuerySingleAsync<int>(sql, field);
        field.Id = id;
        return field.Id > 0;
    }

    public async Task<bool> UpdateField(int fieldId, ReportField field)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = @"UPDATE ReportFields
                    SET Name = @Name
                    WHERE Id = @FieldId";
        var result = await connection.ExecuteAsync(sql, new { Name = field.Name, FieldId = field });
        return result > 0;
    }

    public async Task<bool> DeleteField(int fieldId)
    {
        using var connection = await ConnectionFactory.CreateAsync();
        var sql = "DELETE FROM ReportFields WHERE Id = @FieldId";
        var result = await connection.ExecuteAsync(sql, new { FieldId = fieldId });
        return result > 0;
    }
}