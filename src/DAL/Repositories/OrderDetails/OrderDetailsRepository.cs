using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.OrderDetails;

internal class OrderDetailsRepository : RepositoryBase<OrderDetail>, IOrderDetailsRepository
{
    public OrderDetailsRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    protected override string TableName => "[Order Details]";
}