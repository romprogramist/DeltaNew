using Delta.Helper;

namespace Delta.Services.PhotoAddition;

public class PhotoAddition: IPhotoAddition
{
    public async Task<string> UploadFile(IFormFile file)
    {
        var fileName = Path.GetFileName(file.FileName); // Получаем оригинальное имя файла
        var filePath = Common.GetFilePath(fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(fileStream);

        return fileName;
    }

    public Task<(byte[], string, string)> DownloadFile(string FileName)
    {
        throw new NotImplementedException();
    }
}

// public class Common
// {
//     public static string GetFilePath(string fileName)
//     {
//         throw new NotImplementedException();
//     }
// }