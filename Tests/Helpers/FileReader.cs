using System.Reflection;

namespace Tests.Helpers;

public class FileReader
{
    public static IEnumerable<string> ReadFile(string path)
    {
        string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
        return File.ReadAllLines(filePath);
    }
}
