using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage.Adapters
{
  /// <summary>
  /// 
  /// </summary>
  public class FileAdapter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public List<T> ReadFromFile<T>(string path) where T : class
    {
      if (!File.Exists(path))
      {
        return null;
      }

      var file = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<T>));
      var result = xml.Deserialize(file) as List<T>;

      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void WriteToFile<T>(string path, List<T> data) where T : class
    {
      var file = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(List<T>));

      xml.Serialize(file, data);
    }
  }
}