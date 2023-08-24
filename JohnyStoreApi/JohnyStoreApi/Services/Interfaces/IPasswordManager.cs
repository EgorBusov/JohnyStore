namespace JohnyStoreApi.Services.Interfaces
{
    public interface IPasswordManager
    {
        /// <summary>
        /// Хэширование пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string HashPassword(string password);
    }
}
