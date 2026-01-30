using Newtonsoft.Json;

namespace LIBRARY;

internal static class ReaderRepository
{
    private static string _path = Path.Combine(AppContext.BaseDirectory, "readers.json");
    
    internal static List<Reader>? ReadJsonFile()
    {
        using var r = new StreamReader(_path);
        var jsonRead = r.ReadToEnd();
        var readers = JsonConvert.DeserializeObject<List<Reader>>(jsonRead);
        return readers;
    }
    
    internal static void AddToJsonFile(Reader reader)
    {
        var readers = ReadJsonFile();
        
        try
        {
            readers.Add(reader);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ArgumentNullException(nameof(readers));

        }
        WriteJsonFile(readers);
        
    }

    internal static void WriteJsonFile(List<Reader>? readers)
    {
        var jsonWrite = JsonConvert.SerializeObject(readers, Formatting.Indented);
        File.WriteAllText(_path, jsonWrite);
    }
}