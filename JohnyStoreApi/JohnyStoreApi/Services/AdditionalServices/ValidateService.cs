using JohnyStoreApi.Models.Availability;
using JohnyStoreApi.Models.Brand;
using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreApi.Models.Style;
using JohnyStoreApi.Models.User;
using JohnyStoreData.EF;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Identity.Client;
using System.Text.RegularExpressions;

namespace JohnyStoreApi.Services.AdditionalServices
{
    public static class ValidateService
    {
        private static string _PatternPhone = @"^(\+7|8)\d{10}$";

        //Пароль должен содержать хотя бы 8 символов, включая хотя бы одну заглавную букву, одну строчную букву и одну цифру.
        private static string _PatternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$";

        //Логин может содержать только буквы (как заглавные, так и строчные), цифры и символы подчеркивания.
        //Длина логина ограничивается, например, от 3 до 20 символов.
        private static string _PatternLogin = @"^[a-zA-Z0-9_]{3,20}$";

        #region Availability

        /// <summary>
        /// Валидация модели наличия
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool Validate(this AvailabilityModel model, JohnyStoreContext context)
        {
            if (model == null)
                return false;

            var statuses = context.AvailabilityStatuses
                .Where(x => x.Visible == true)
                .Select(x => x.Id)
                .ToList();

            if (!statuses.Any(x => x == model.Status35.Id) ||
                !statuses.Any(x => x == model.Status36.Id) ||
                !statuses.Any(x => x == model.Status37.Id) ||
                !statuses.Any(x => x == model.Status38.Id) ||
                !statuses.Any(x => x == model.Status39.Id) ||
                !statuses.Any(x => x == model.Status40.Id) ||
                !statuses.Any(x => x == model.Status41.Id) ||
                !statuses.Any(x => x == model.Status42.Id) ||
                !statuses.Any(x => x == model.Status43.Id) ||
                !statuses.Any(x => x == model.Status44.Id) ||
                !statuses.Any(x => x == model.Status45.Id) ||
                !statuses.Any(x => x == model.Status46.Id))
            {
                return false;
            }

            var sneaker = context.ModelsSneakers.FirstOrDefault(x => x.Id == model.Model.Id);

            if (sneaker == null)
                return false;

            return true;
        }

        /// <summary>
        /// Валидация статуса наличия
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate(this AvailabilityStatusModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name))
                return false;

            return true;
        }

        #endregion

        #region Brand

        /// <summary>
        /// Валидация модели добавления бренда
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate(this AddBrandModel model)
        {
            if (model.Name == null || !model.Picture.Validate())
                return false;

            return true;
        }

        /// <summary>
        /// Валидация модели добавления картинки бренда
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate(this AddPictureBrandModel model)
        {
            if (model == null ||
                model.IdBrand == 0 ||
                model.File == null ||
                model.File.Length == 0)
                return false;

            return true;
        }

        #endregion

        #region Order

        /// <summary>
        /// Валидация заказа
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool Validate(this OrderModel model, JohnyStoreContext context)
        {
            var idStatuses = context.OrderStatuses.Where(x => x.Visible == true).Select(x => x.Id);
            var idModels = context.ModelsSneakers.Where(x => x.Visible == true).Select(x => x.Id);

            if (model == null ||
                model.SizeFoot == 0 ||
                string.IsNullOrEmpty(model.Email) ||
                !Regex.IsMatch(model.Phone, _PatternPhone) ||
                !idStatuses.Any(x => x == model.Status.Id) ||
                !idModels.Any(x => x == model.Model.Id))
                return false;

            return true;
        }

        /// <summary>
        /// Валидация статуса заказа
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool Validate(this OrderStatusModel model, JohnyStoreContext context)
        {
            var positions = context.OrderStatuses.Where(x => x.Visible == true).Select(x => x.Position);

            if (model == null ||
                string.IsNullOrEmpty(model.Name) ||
                model.Position == 0 ||
                !positions.Any(x => x == model.Position))
                return false;

            return true;
        }

        #endregion

        #region Sneaker

        /// <summary>
        /// Валидация модели добавления кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool Validate(this AddSneakerModel model, JohnyStoreContext context)
        {
            var idBrands = context.Brands.Where(x => x.Visible == true).Select(x => x.Id);
            var idStyles = context.Styles.Where(x => x.Visible == true).Select(x => x.Id);

            if (model == null ||
                !idBrands.Any(x => x == model.Brand) ||
                string.IsNullOrEmpty(model.Name) ||
                model.Price == 0 ||
                string.IsNullOrEmpty(model.Description) ||
                !idStyles.Any(x => x == model.Style) ||
                string.IsNullOrEmpty(model.Article) ||
                string.IsNullOrEmpty(model.Color))
                return false;

            return true;
        }

        /// <summary>
        /// Валидация коллекции картинок для кроссовок
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static bool Validate(this List<AddPictureSneakerModel> models)
        {
            if (models == null ||
                models.Count == 0 ||
                models.Where(x => x.Main == true).Count() != 1)
                return false;

            foreach (var model in models)
            {
                if (model == null || model.File == null || model.File.Length == 0)
                    return false;
            }

            return true;
        }

        #endregion

        #region Style

        /// <summary>
        /// Валидация стиля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate(this StyleModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name))
                return false;

            return true;
        }

        #endregion

        #region User

        /// <summary>
        /// Валидация логина и пароля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate(this LogPassModel model)
        {
            if(model == null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
                return false;

            if (!Regex.IsMatch(model.UserName, _PatternLogin) || !Regex.IsMatch(model.Password, _PatternPassword))
                return false;

            return true;
        }

        /// <summary>
        /// Валидация модели изменения пароля
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Validate(this EditPasswordModel model)
        {
            if (model == null || 
                string.IsNullOrEmpty(model.UserName) || 
                string.IsNullOrEmpty(model.Password) ||
                string.IsNullOrEmpty(model.NewPassword))
                return false;

            if(model.Password == model.NewPassword) 
                return false;

            if (!Regex.IsMatch(model.UserName, _PatternLogin) || 
                !Regex.IsMatch(model.Password, _PatternPassword) ||
                !Regex.IsMatch(model.NewPassword, _PatternPassword))
                return false;

            return true;
        }

        #endregion

    }
}
