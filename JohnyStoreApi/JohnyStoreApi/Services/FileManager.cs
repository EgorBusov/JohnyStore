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

            }
            catch 
            {
                return Stream.Null;
            }
        }

        /// <summary>
        /// Соxранение файла, возврат имя файла
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string SaveFile(Stream stream, string pathDirectory)
        {
            try
            {

            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// изменение/замена файла. Возврат имя файла
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string UpdateFile(Stream stream, string pathDirectory, string fileName)
        {
            try
            {

            }
            catch
            {

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

            }
            catch
            {
                return false;
            }
        }
    }
}
