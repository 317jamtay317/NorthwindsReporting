using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Suppliers;

internal class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
{
    public SupplierRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    protected override string TableName => "Suppliers";
}