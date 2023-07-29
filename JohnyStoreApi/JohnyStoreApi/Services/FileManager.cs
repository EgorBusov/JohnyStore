namespace JohnyStoreApi.Services
{
    /// <summary>
    /// Класс для работы с файлами
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Получение потока файла по пути
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Stream GetFile(string path)
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
        public static string SaveFile(Stream streamFile, string pathDirectory, string extentionSavedFile)
        {
            if(!ValidateFile(streamFile))
                return String.Empty;

            try
            {
                var newFileName = Guid.NewGuid().ToString() + extentionSavedFile;
                using(var stream = File.OpenWrite(pathDirectory + newFileName))
                {
                    stream.CopyTo(streamFile);
                }

                return newFileName;
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// изменение/замена файла. Возврат имя файла/пустая строка
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string UpdateFile(Stream streamFile, string pathOldFile, string extentionNewFile)
        {
            if (!ValidateFile(streamFile))
                return String.Empty;

            try
            {
                string fileName = SaveFile(streamFile, pathOldFile, Path.GetExtension(pathOldFile));
                DeleteFile(pathOldFile);

                return fileName;
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DeleteFile(string path)
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
        /// валидация потока/файла
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static bool ValidateFile(Stream stream)
        {
            if (stream == null || stream.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
