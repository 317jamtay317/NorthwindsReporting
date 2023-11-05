using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Products;

internal class ProductsRepository : RepositoryBase<Product>, IProductsRepository
{
    public ProductsRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    protected override string TableName => "Products";
}