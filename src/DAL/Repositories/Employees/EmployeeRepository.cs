using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Employees
{
    internal class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        protected override string TableName => "Employees";
    }
}
