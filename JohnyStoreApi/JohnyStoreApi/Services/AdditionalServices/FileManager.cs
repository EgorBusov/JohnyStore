using JohnyStoreApi.Services.Interfaces;

namespace JohnyStoreApi.Services.AdditionalServices
{
    /// <summary>
    /// Класс для работы с файлами
    /// </summary>
    public class FileManager : IFileManager
    {

        private readonly IConfiguration _configuration;

        public FileManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Получение потока файла по пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stream GetFile(string path)
        {
            try
            {
                return File.OpenRead(path);
            }
            catch
            {
                return Stream.Null;
            }
        }

        /// <summary>
        /// Соxранение файла, возврат имя файла/пустая строка
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public string SaveFile(Stream streamFile, string fullPathDirectory, string extentionSavedFile)
        {
            if (!ValidateFile(streamFile))
                return string.Empty;

            try
            {
                var newFileName = Guid.NewGuid().ToString() + extentionSavedFile;
                using (var stream = File.OpenWrite(Path.Combine(fullPathDirectory, newFileName)))
                {
                    streamFile.CopyTo(stream);
                }

                return newFileName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// изменение/замена файла. Возврат имя файла/пустая строка
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string UpdateFile(Stream streamFile, string pathOldFile, string extentionNewFile)
        {
            if (!ValidateFile(streamFile))
                return string.Empty;

            try
            {
                string fileName = SaveFile(streamFile, pathOldFile, extentionNewFile);
                DeleteFile(pathOldFile);

                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка на наличие и создание файлов в приложении
        /// </summary>
        public void CheckAndCreateDirectoryOrFilesForApp()
        {
            var pathDomain = AppDomain.CurrentDomain.BaseDirectory;

            var pathDirectoryPictureForSneaker =
                Path.Combine(pathDomain, _configuration.GetValue<string>("Paths:PathDirectoryPictureForSneaker"));
            var pathDirectoryPictureForBrand =
                Path.Combine(pathDomain, _configuration.GetValue<string>("Paths:PathDirectoryPictureForBrand"));

            List<string> directories = new List<string>() 
            { pathDirectoryPictureForSneaker, pathDirectoryPictureForBrand};

            foreach (var directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
        }

        /// <summary>
        /// валидация потока/файла
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private bool ValidateFile(Stream stream)
        {
            if (stream == null || stream.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
