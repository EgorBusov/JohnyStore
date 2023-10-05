using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Style;
using JohnyStoreApi.Services.AdditionalServices;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;

namespace JohnyStoreApi.Services.DataServices
{
    public class StyleDataService : IStyleDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;
        private readonly IConfiguration _configuration;

        public StyleDataService(JohnyStoreContext context, IJohnyStoreLogger logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Получение всех стилей
        /// </summary>
        /// <returns></returns>
        public List<StyleModel> GetStyles()
        {
            return _context.Styles.Where(x => x.Visible == true).ToList().MapToStyleModels();
        }

        /// <summary>
        /// Получение стиля по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StyleModel GetStyleById(int id) 
        {
            try
            {
                var style = _context.Styles.FirstOrDefault(x => x.Id == id && x.Visible == true) 
                    ?? throw new Exception("Стиль не найден");

                return style.MapToStyleModel();
            }
            catch(Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return new StyleModel();
            }
        }

        /// <summary>
        /// Добавление стиля
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public bool AddStyle(StyleModel model)
        {
            if(!model.Validate()) 
                return false;

            _context.Styles.Add(model.MapToStyle());

            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// Добавление стиля
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public bool EditStyle(StyleModel model)
        {
            try
            {
                if (!model.Validate() || model.Id == 0)
                    return false;

                var style = _context.Styles.FirstOrDefault(x => x.Id == model.Id && x.Visible == true) 
                    ?? throw new Exception("Стиль не найден");

                style.Name = model.Name;

                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Удаления стиля
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStyle(int id)
        {
            try
            {
                var sneakersId = _context.ModelsSneakers.Where(x => x.Style.Id == id).Select(x => x.Id);
                if (sneakersId.Count() > 0)
                    throw new Exception("Еще остались модели кроссовок, которые используют этот стиль");

                var style = _context.Styles.FirstOrDefault(x => x.Id == id && x.Visible == true) 
                    ?? throw new Exception("Стиль не найден");

                _context.Styles.Remove(style);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }
    }
}
