using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Customers;

internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(IConnectionFactory connectionFactory) 
        : base(connectionFactory)
    {
    }

    protected override string TableName => "Customers";
}