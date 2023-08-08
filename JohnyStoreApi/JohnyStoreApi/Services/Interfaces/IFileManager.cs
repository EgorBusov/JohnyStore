namespace JohnyStoreApi.Services.Interfaces
{
    /// <summary>
    /// Работа с файлами
    /// </summary>
    public interface IFileManager
    {
        Stream GetFile(string path);
        string SaveFile(Stream streamFile, string fullPathDirectory, string extentionSavedFile);
        string UpdateFile(Stream streamFile, string pathOldFile, string extentionNewFile);
        bool DeleteFile(string path);
    }
}
