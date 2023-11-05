using DAL.Connection;
using DAL.Repositories.Base;

namespace DAL.Repositories.Regions;

internal class RegionRepository : RepositoryBase<Region>, IRegionRepository
{
    public RegionRepository(IConnectionFactory connection): base(connection) { }
       
    protected override string TableName => "Regions";
}