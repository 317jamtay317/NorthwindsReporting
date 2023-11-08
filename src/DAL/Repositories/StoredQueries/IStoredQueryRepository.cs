using DAL.Repositories.Base;
using Models;

namespace DAL.Repositories.StoredQueries;

public interface IStoredQueryRepository : IRepository<StoredQuery>
{
    /// <summary>
    /// Creates a new query in the database
    /// </summary>
    Task<bool> Create(StoredQuery storedQuery);

    /// <summary>
    /// Updates the existing query in the database
    /// </summary>
    Task<bool> Update(StoredQuery storedQuery);

    /// <summary>
    /// Deletes the associated query from the database
    /// </summary>
    Task<bool> Delete(int id);
}