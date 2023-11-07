namespace DAL.Database;

public interface IDatabaseInitializer
{
    /// <summary>
    /// initializes any configuration in the database
    /// </summary>
    public Task Init();
}