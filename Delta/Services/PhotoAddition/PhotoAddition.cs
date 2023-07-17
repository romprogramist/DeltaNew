using System.Security.AccessControl;
using Delta.Helper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Delta.Services.PhotoAddition;

public class PhotoAddition: IPhotoAddition
{
    public async Task<string> UploadFile(IFormFile _IFormFile)
    {
        string FileName = "";
        try
        {
            FileInfo _FileInfo = new FileInfo(_IFormFile.FileName);
            FileName = _IFormFile.FileName + "_" + DateTime.Now.Ticks.ToString() + _FileInfo.Extension;
            var _GetFilePath = Common.GetFilePath(FileName);
            using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
            {
                await _IFormFile.CopyToAsync(_FileStream);
            }
            return FileName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
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