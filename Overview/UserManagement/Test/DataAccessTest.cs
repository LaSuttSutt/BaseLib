using NUnit.Framework;
using UserManagement.DomainModel;

namespace UserManagement.Test;

[TestFixture]
public class DataAccessTest
{
    [Test]
    public void ConnectionTest()
    {
        var data = new Data.Data();

        var user = new User() { Id = Guid.NewGuid(), Name = "Sven Sutter" };
        data.Model.AddObject(user);
    }
}