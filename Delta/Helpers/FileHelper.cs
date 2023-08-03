namespace Delta.Helpers;

// public class FileHelper
// {
//     public static string GetUniqueFileName(string filePath)
//     {
//         var fileName = Path.GetFileName(filePath);
//         return string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(fileName));
//     }
// }

public class FileHelper
{
    public static string GetUniqueFileName(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        return string.Concat(DateTime.Now.Ticks, Path.GetExtension(fileName));
    }
}