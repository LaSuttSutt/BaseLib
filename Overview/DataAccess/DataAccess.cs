using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class DataAccess : DbContext, IDataAccess
{
    #region Declarations

    private string DatabaseName { get; }
    private List<Type> DomainModel { get; }

    #endregion

    #region C'tor

    public DataAccess(string dbName, List<Type> domainModel)
    {
        DatabaseName = dbName;
        DomainModel = domainModel;
        Database.EnsureCreated();
    }

    #endregion

    #region DbContext

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql($"server=localhost;port=3306;database={DatabaseName};user=svs;password=mariadb",
            new MariaDbServerVersion(new Version(10, 6, 0)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        DomainModel.ForEach(bc => modelBuilder.Entity(bc));
        base.OnModelCreating(modelBuilder);
    }

    #endregion
    
    #region IDataAccess

    public void AddObject<T>(T newObject) where T : class
    {
        Set<T>().Add(newObject);
        SaveChanges(true);
    }
    
    #endregion
}