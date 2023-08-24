using JohnyStoreApi.Data.Models;

namespace JohnyStoreApi.Services.Interfaces
{
    public interface IJWT
    {       
        /// <summary>
        /// Генерация jwt-токена
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        string GenerateJWT(User userInfo);
    }
}
