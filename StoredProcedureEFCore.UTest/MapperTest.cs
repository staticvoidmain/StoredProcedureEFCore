using System;
using System.Collections.Generic;
using System.Data.Common;

using Moq;
using Moq.DataReader;

using NUnit.Framework;

namespace StoredProcedureEFCore.UTest
{
  public class MapperTests
  {
    public class HasReadOnly
    {
      public int Id { get; } = 1;

      public string Name { get; set; }
    }

    [Test]
    public void Tolerates_Null_Input()
    {
      // a row full of dbnulls
      var m = Setup<DbModel, TestModel>(new List<DbModel>
      {
        new DbModel()
      });

      m.Map(t =>
      {
        Assert.IsNotNull(t);
      });
    }

    [Test]
    public void It_Should_Ignore_Readonly_Properties()
    {
        var m = Setup<HasReadOnly, HasReadOnly>(new List<HasReadOnly>
        {
          new HasReadOnly() { Name = "Bob" }
        });

        m.Map(t =>
        {
          Assert.AreEqual(1, t.Id);
          Assert.AreEqual("Bob", t.Name);
        });
    }

    private static Mapper<TDest> Setup<TSrc, TDest>(List<TSrc> results)
      where TDest : class, new()
    {
      var mock = new Mock<DbDataReader>();
      mock.SetupDataReader<TSrc>(results);
      var m = new Mapper<TDest>(mock.Object);
      return m;
    }
  }
}
