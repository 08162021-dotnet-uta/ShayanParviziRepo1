using System.Collections.Generic;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;

namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomerRepository : IRepository<Customer>
  {
    private const string _path = @"/home/shyguy/revature/shayan_repo/data/customers.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();

    public CustomerRepository()
    {
      if (_fileAdapter.ReadFromFile<Customer>(_path) == null)
      {
        _fileAdapter.WriteToFile<Customer>(_path, new List<Customer>());
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool Insert(Customer entry)
    {
      _fileAdapter.WriteToFile<Customer>(_path, new List<Customer> { entry });

      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Customer> Select()
    {
      return _fileAdapter.ReadFromFile<Customer>(_path);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Customer Update()
    {
      throw new System.NotImplementedException();
    }
  }
}