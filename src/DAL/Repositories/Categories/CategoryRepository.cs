using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Categories;

internal class CategoryRepository : RepositoryBase<Category>,  ICategoryRepository
{
    public CategoryRepository(IConnectionFactory connectionFactory) 
        : base(connectionFactory)
    {
    }

    protected override string TableName => "Categories";
}