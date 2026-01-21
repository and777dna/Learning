namespace Library.customJSONutils;

public class ReadJson//Library.customJSONutils.ReadJson
{
    internal static string ReadJsonFile(string path)
    {
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
        return readText;
    }
}