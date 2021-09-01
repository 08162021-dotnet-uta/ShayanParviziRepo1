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
    private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;
    private const string _logFilePath = @"/home/fred/revature/fred_repo/data/logs.txt";

    /// <summary>
    /// Defines the Main Method
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();
      //   //DataAdapter data = new DataAdapter();
      //         //HelloSQL();
      //  //       var customer = data.Customers.ToList();
      //         foreach(var c in customer)
      //         {
      //             Console.WriteLine($"{c.Name}, {c.CustomerId}");
      //         }
      Run();
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
      var product = _productSingleton.Products[Capture<Product>(_productSingleton.Products)];
      Console.WriteLine(customer);
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Output<Store>(List<Store> data)
    {
      Log.Information($"method: Output<{typeof(Store)}>()");

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
      Computer c = new Computer();
      Monitor m = new Monitor();
      Pickles p = new Pickles();
      if (selected == 1)
      {
        Console.WriteLine("Select a store:");


      }
      else if (selected == 2)
      {
        Console.WriteLine(p);
      }
      else if (selected == 3)
      {
        Console.WriteLine(c);
        Console.WriteLine(m);
      }

      return selected - 1;
    }


    // private static void HelloSQL()
    // {
    //   var def = new DemoEF();

    //   def.SetCustomer(new Customer());

    //   foreach (var item in def.GetCustomers())
    //   {
    //     Console.WriteLine(item);
    //   }
    // }
  }
}