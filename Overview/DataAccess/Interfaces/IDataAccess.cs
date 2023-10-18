namespace DataAccess.Interfaces;

public interface IDataAccess
{
    void AddObject<T>(T newObject) where T : class;
}