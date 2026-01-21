using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine("vdfv");

namespace Library
{
   internal class Program
   {
      /*private class Book
      {
         public string Author {get; set;}
         public string Title {get; set;}
         public string Year {get; set;}
         public string PublishedNumber {get; set;}
      }*/
      
      public class data
      {
         public int Id { get; set; }
         public int SSN { get; set; }
         public string Message { get; set;}
      }

      public static void Main()
      {
         
         List<data> _data = new List<data>();
         _data.Add(new data()
         {
            Id = 1,
            SSN = 2,
            Message = "A Message"
         });
         
         string json = JsonSerializer.Serialize(_data);
         var filePath = Path.Combine(AppContext.BaseDirectory, "path.json");
         Console.WriteLine("filePath:" + filePath);
         File.WriteAllText(filePath, json);
      }
      

        
      }
   
}
/*Консольный проект + json для хранения данных.
   - Класс Book (Author, Name, Year)
   - [CRUD](https://skyeng.ru/magazine/wiki/it-industriya/chto-takoe-crud/) операции (создать, получить, обновить, удалить книгу из источника данных)
   - Поиск по автору/названию/году
   
   - Сортировка по популярности (кол-во выдач)
   - Выдача/возврат книг с датами
*/