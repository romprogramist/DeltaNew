namespace Delta.Services.PhotoAddition;

public interface IPhotoAddition
{
    Task<string> UploadFile(IFormFile _iFormFile);
    Task<(byte[], string, string)> DownloadFile(string FileName);
}