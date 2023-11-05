using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Orders;

internal class OrderRepository : RepositoryBase<Order> , IOrderRepository
{
    public OrderRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    protected override string TableName => "Orders";
}