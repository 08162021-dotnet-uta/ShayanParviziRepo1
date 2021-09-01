using System;
using System.Collections.Generic;
using System.Linq;
using Project0.StoreApplication.Client.Singletons;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage;
using Project0.StoreApplication.Storage.Adapters;
using Serilog;

namespace Project0.StoreApplication.Client
{
  /// <summary>
  /// 
  /// </summary>
  internal class Program
  {
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private const string _logFilePath = @"/home/fred/revature/fred_repo/data/logs.txt";

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();
      DataAdapter data = new DataAdapter();
            //HelloSQL();
            var customer = data.Customers.ToList();
            foreach(var c in customer)
            {
                Console.WriteLine($"{c.Name}, {c.CustomerId}");
            }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      Log.Information("method: Run()");

      if (_customerSingleton.Customers.Count == 0)
      {
        _customerSingleton.Add(new Customer());
      }

      var customer = _customerSingleton.Customers[Capture<Customer>(_customerSingleton.Customers)];
      var store = _storeSingleton.Stores[Capture<Store>(_storeSingleton.Stores)];

      Console.WriteLine(customer);
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Output<T>(List<T> data) where T : class
    {
      Log.Information($"method: Output<{typeof(T)}>()");

      var index = 0;

      foreach (var item in data)
      {
        Console.WriteLine($"[{++index}] - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static int Capture<T>(List<T> data) where T : class
    {
      Log.Information("method: Capture()");

      Output<T>(data);
      Console.Write("make selection: ");

      int selected = int.Parse(Console.ReadLine());

      return selected - 1;
    }

    private static void HelloSQL()
    {
      var def = new DemoEF();

      def.SetCustomer(new Customer());

      foreach (var item in def.GetCustomers())
      {
        Console.WriteLine(item);
      }
    }
  }
}