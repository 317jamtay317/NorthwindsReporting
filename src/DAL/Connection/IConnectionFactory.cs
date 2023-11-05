using System.Data;
using System.Threading.Tasks;

namespace DAL.Connection
{
    public interface IConnectionFactory
    {
        Task<IDbConnection> CreateAsync();
    }
}