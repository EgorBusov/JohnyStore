using JohnyStoreApi.Data.Models;
using JohnyStoreApi.Logging;
using JohnyStoreApi.Models.User;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreData.EF;

namespace JohnyStoreApi.Services.AdditionalServices
{
    public class UserService : IUserService
    {
        private readonly JohnyStoreContext _context;
        private readonly JohnyStoreLogger _logger;
        private readonly IJWT _jwt;
        private readonly IPasswordManager _passwordManager;

        public UserService(JohnyStoreContext context, JohnyStoreLogger logger, IJWT jwt, IPasswordManager passwordManager)
        {
            _context = context;
            _logger = logger;
            _jwt = jwt;
            _passwordManager = passwordManager;
        }

        /// <summary>
        /// Добавление юзера
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddUser(LogPassModel model)
        {
            if(!model.Validate() || CheckUser(model))
            {
                _logger.InfoLog("Пароль и логин не соответствуют требуемому формату или пользователь с такими данными существует");
                return string.Empty;
            }

            User user = new User()
            {
                Email = "-", //просто пока заглушка, потом можно будет расширить функционал
                PasswordHash = _passwordManager.HashPassword(model.Password),
                Role = "Admin",
                UserName = model.UserName
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return _jwt.GenerateJWT(user) ?? string.Empty;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Login(LogPassModel model)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.UserName == model.UserName && x.PasswordHash == _passwordManager.HashPassword(model.Password));

            if(user == null)
                return string.Empty;

            return _jwt.GenerateJWT(user) ?? string.Empty;
        }

        /// <summary>
        /// Изменение пароля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string EditPassword(EditPasswordModel model)
        {
            if (!model.Validate())
                return string.Empty;

            var user = _context.Users
                .FirstOrDefault(x => x.UserName == model.UserName && x.PasswordHash == _passwordManager.HashPassword(model.Password));

            if (user == null)
                return string.Empty;

            user.PasswordHash = _passwordManager.HashPassword(model.NewPassword);
            _context.SaveChanges();

            return _jwt.GenerateJWT(user);
        }

        /// <summary>
        /// Проверка на юзера с таким же логином и паролем
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool CheckUser(LogPassModel model)
        {
            var users = _context.Users
                .Where(x => x.UserName == model.UserName && x.PasswordHash == _passwordManager.HashPassword(model.Password))
                .ToList();

            return users.Count > 0;
        }
    }
}
