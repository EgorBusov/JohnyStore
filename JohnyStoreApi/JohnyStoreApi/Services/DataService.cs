using JohnyStoreApi.Models;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreData.EF;
using JohnyStoreData.Models;

namespace JohnyStoreApi.Services
{
    /// <summary>
    /// Сервис для работы с данными
    /// </summary>
    public class DataService
    {
        private readonly JohnyStoreContext _context;
        public DataService(JohnyStoreContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Получение коллекции кроссовок с учетом фильтра
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<SneakerModel> GetSneakers(SearchModel? search = null)
        {
            var list = Search(search).ToList().MapToSneakerModels(_context) ?? new List<SneakerModel>();
            return list;          
        }

        /// <summary>
        /// Получение кроссовок по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SneakerModel GetSneakerByid(int id)
        {
            Sneaker modelSneaker = _context.ModelsSneakers.FirstOrDefault(x => x.Id == id) ?? new Sneaker();
            return modelSneaker.MapToSneakerModel(_context);
        }

        public bool AddSneaker(SneakerModel model)
        {
            try
            {
                using(var transaction = _context.Database.BeginTransaction())
                {


                    _context.PictureSneakers.AddRange(model.Pictures.MapToPictureSneakers());

                    transaction.Commit();
                }

            }
            catch 
            {
                return false
            }
        }

        private IQueryable<Sneaker> Search(SearchModel search)
        {
            
            var query = _context.ModelsSneakers.AsQueryable().Where(x => x.Visible == true);

            if(search == null) { return query; }

            if(search.ModelId > 0 ) { query = query.Where(x => x.Id == search.ModelId); }
            if(search.BrandId > 0) { query = query.Where(x => x.IdBrand == search.BrandId); }
            if(search.Name != null) { query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower())); }
            if(search.PriceMin > 0) { query = query.Where(x => x.Price >= search.PriceMin); }
            if(search.PriceMax > 0) { query = query.Where(x => x.Price <= search.PriceMax); }
            if(search.Geneder != null)
            {
                if (search.Geneder.ToLower() == "wooman") { query = query.Where(x => x.Gender == false); }
                if (search.Geneder.ToLower() == "man") { query = query.Where(x => x.Gender == true); }
            }

            if(search.WinterOrSummer != null)
            {
                if (search.WinterOrSummer.ToLower() == "summer") { query = query.Where(x => x.WinterOrSummer == true); }
                if (search.WinterOrSummer.ToLower() == "winter") { query = query.Where(x => x.WinterOrSummer == false); }
            }

            if(search.StyleId > 0) { query = query.Where(x => x.IdStyle == search.StyleId); }
            if(search.Article != null) { query = query.Where(x => x.Article == search.Article); }
            if(search.Sale == true) { query = query.Where(x => x.Sale == search.Sale); }
            if(search.New == true) { query = query.Where(x => x.New == search.New); }

            return query;

        }
    }
}
