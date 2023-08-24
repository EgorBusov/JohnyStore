using JohnyStoreApi.Models.User;

namespace JohnyStoreApi.Services.Interfaces
{
    public interface IUserService
    {
        string AddUser(LogPassModel model);
        string Login(LogPassModel model);
        string EditPassword(EditPasswordModel model);
    }
}
