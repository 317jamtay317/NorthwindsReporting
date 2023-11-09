using DAL.Repositories.Base;
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

    /// <summary>
    /// Returns all of the fields associated with that report
    /// </summary>
    public Task<IEnumerable<ReportField>> GetFields(int reportId);

    /// <summary>
    /// Creates a new field int the database for the passed in report Id
    /// </summary>
    public Task<bool> CreateField(int reportId, ReportField  field);

    /// <summary>
    /// Updates the field in the database with the new values
    /// </summary>
    public Task<bool> UpdateField(int fieldId, ReportField field);

    /// <summary>
    /// Deletes the field from the database
    /// </summary>
    public Task<bool> DeleteField(int fieldId);

    
}