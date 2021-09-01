using Xunit;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;

namespace Project0.StoreApplication.Testing
{
  public class StoreRepositoryTests
  {
    [Fact]
    public void Test_StoreCollection()
    {
      // arrange = instance of the entity to test
      var sut = StoreSingleton.Instance;

      // act = execute sut for data
      var actual = sut.Stores;

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_FileAdapter_Positive()
    {
      var sut = new FileAdapter();

      var actual = sut.ReadFromFile<object>("path");

      Assert.IsType<List<object>>(actual);
      Assert.NotEmpty(actual);
    }

    [Fact]
    public void Test_FileAdapter_Negative()
    {
      var sut = new FileAdapter();

      var actual = sut.ReadFromFile<object>("path");

      Assert.IsType<List<object>>(actual);
      Assert.Null(actual);
    }
  }
}