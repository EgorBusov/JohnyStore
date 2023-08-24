using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreApi.Services.AdditionalServices;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using JohnyStoreData.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Drawing;
using System.Reflection;
using System.Threading.Channels;

namespace JohnyStoreApi.Services.Data
{
    /// <summary>
    /// CRUD для кроссовок
    /// </summary>
    public class SneakerDataSevice : ISneakerDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;
        private readonly IPictureSneakerDataService _pictureDataService;
        private readonly IConfiguration _configuration;

        public SneakerDataSevice(
            JohnyStoreContext context,
            IJohnyStoreLogger logger,
            IPictureSneakerDataService pictureDataService,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _pictureDataService = pictureDataService;
            _configuration = configuration;
        }


        /// <summary>
        /// Получение коллекции кроссовок с учетом фильтра
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<SneakerModel> GetSneakers(SearchModel? search)
        {
            var list = Search(search).ToList().MapToSneakerModels(_context, _configuration) ?? new List<SneakerModel>();
            return list;
        }

        /// <summary>
        /// Получение кроссовок по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SneakerModel GetSneakerByid(int id)
        {
            Sneaker modelSneaker = _context.ModelsSneakers.FirstOrDefault(x => x.Id == id && x.Visible == true) ?? new Sneaker();
            return modelSneaker.MapToSneakerModel(_context, _configuration);
        }

        /// <summary>
        /// Добавление модели кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSneaker(AddSneakerModel model)
        {
            if(!model.Validate(_context)) 
                return false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Sneaker sneaker = model.MapToSneaker(_context);
                    _context.ModelsSneakers.Add(sneaker);
                    bool check = _pictureDataService.AddPictures(model.Pictures, sneaker);

                    int changes = _context.SaveChanges();
                    transaction.Commit();
                    return changes > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.ErrorLog(ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Редактирование кроссовок
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditSneaker(AddSneakerModel model)
        {
            if (model.Id == 0 || !model.Validate(_context))
                return false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Sneaker sneaker = _context.ModelsSneakers.First(x => x.Id == model.Id && x.Visible == true) 
                        ?? throw new Exception("Модель не найдена");
                    Brand brand = _context.Brands.First(x => x.Id == model.Brand) ?? throw new Exception("Брэнд не найден");
                    Style style = _context.Styles.First(x => x.Id == model.Style) ?? throw new Exception("Стиль не найден");

                    sneaker.Brand = brand;
                    sneaker.Name = model.Name;
                    sneaker.Price = model.Price;
                    sneaker.Description = model.Description;
                    sneaker.Gender = model.Gender;
                    sneaker.WinterOrSummer = model.WinterOrSummer;
                    sneaker.Style = style;
                    sneaker.Article = model.Article;
                    sneaker.Sale = model.Sale;
                    sneaker.New = model.New;
                    sneaker.Color = model.Color;
                    sneaker.Visible = true;

                    bool checkDel = _pictureDataService.DeletePictures(sneaker.Id);
                    bool checkSave = _pictureDataService.AddPictures(model.Pictures, sneaker);

                    int changes = _context.SaveChanges();
                    transaction.Commit();
                    return changes > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.ErrorLog(ex.Message);
                    return false;
                }
            }

        }

        /// <summary>
        /// Удаление модели кроссовок
        /// </summary>
        /// <param name="idModel"></param>
        /// <returns></returns>
        public bool DeleteSneaker(int idModel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Sneaker sneaker = _context.ModelsSneakers.First(x => x.Id == idModel) ?? throw new Exception("Модель не найдена");

                    sneaker.Visible = false;
                    _pictureDataService.DeletePictures(sneaker.Id);

                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    _logger.ErrorLog(ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Метод составления запроса из параметров поиска
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private IQueryable<Sneaker> Search(SearchModel? search)
        {

            var query = _context.ModelsSneakers.AsQueryable().Where(x => x.Visible == true);

            if (search == null) { return query; }

            if (search.ModelId > 0) { query = query.Where(x => x.Id == search.ModelId); }
            if (search.BrandId > 0) { query = query.Where(x => x.Brand.Id == search.BrandId); }
            if (search.Name != null) { query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower())); }
            if (search.PriceMin > 0) { query = query.Where(x => x.Price >= search.PriceMin); }
            if (search.PriceMax > 0) { query = query.Where(x => x.Price <= search.PriceMax); }
            if (search.Geneder != null)
            {
                if (search.Geneder.ToLower() == "wooman") { query = query.Where(x => x.Gender == false); }
                if (search.Geneder.ToLower() == "man") { query = query.Where(x => x.Gender == true); }
            }

            if (search.WinterOrSummer != null)
            {
                if (search.WinterOrSummer.ToLower() == "summer") { query = query.Where(x => x.WinterOrSummer == true); }
                if (search.WinterOrSummer.ToLower() == "winter") { query = query.Where(x => x.WinterOrSummer == false); }
            }

            if (search.StyleId > 0) { query = query.Where(x => x.Style.Id == search.StyleId); }
            if (search.Article != null) { query = query.Where(x => x.Article == search.Article); }
            if (search.Sale == true) { query = query.Where(x => x.Sale == search.Sale); }
            if (search.New == true) { query = query.Where(x => x.New == search.New); }

            return query;
        }
    }
}
