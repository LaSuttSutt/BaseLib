using DataAccess.Interfaces;
using UserManagement.DomainModel;

namespace UserManagement.Data;

public class Data
{
    #region Declarations

    public IDataAccess Model { get; set; }

    #endregion

    #region C'tor

    public Data()
    {
       var models = new List<Type> { typeof(User) };

       Model = new DataAccess.DataAccess("baselib_test", models);
    }

    #endregion
}