using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Base
{
    /// <summary>
    /// A generic repository interface defines the standard operations to be performed on a model.
    /// </summary>
    /// <typeparam name="T">The type of the model that this repository will operate on.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves the entity of type T by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity found with the given identifier.</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Retrieves all entities of type T asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of all entities of type T.</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Gets the count of all entities of type T asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of entities of type T.</returns>
        Task<int> Count();
    }

}