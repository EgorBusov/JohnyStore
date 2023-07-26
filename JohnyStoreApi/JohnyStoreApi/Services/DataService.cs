using JohnyStoreApi.Models;
using JohnyStoreData.EF;
using JohnyStoreData.Models;

namespace JohnyStoreApi.Services
{
    public class DataService
    {
        private readonly JohnyStoreContext _context;
        public DataService(JohnyStoreContext context) 
        {
            _context = context;
        }

        public List<SneakerModel> GetSneakers(SearchModel search = null)
        {
            var query = Search(search).ToList();
            return MapToSneakerModels(query) ?? new List<SneakerModel>();
            
        }

        private List<SneakerModel> MapToSneakerModels(List<ModelSneaker> modelSneakers)
        {
            List<SneakerModel> sneakerModels = new List<SneakerModel>();

            foreach(var model in modelSneakers)
            {
                Brand brand = _context.Brands.First(x => x.Id == model.IdBrand);
                List<PictureSneaker> pictures = _context.PictureSneakers.Where(x => x.IdModel == model.Id).ToList();
                Style style = _context.Styles.First(x => x.Id == model.IdStyle);

                SneakerModel sneakerModel = new SneakerModel()
                {
                    Id = model.Id,
                    Brand = new BrandModel()
                    {
                        Id = brand.Id,
                        Name = brand.Name
                    },
                    Name = model.Name,
                    Pictures = new List<PictureSneakerModel>(),
                    Price = model.Price,
                    Description = model.Description,
                    Gender = model.Gender,
                    WinterOrSummer = model.WinterOrSummer,
                    Style = new StyleModel()
                    {
                        Id = style.Id,
                        Name = style.Name
                    },
                    Article = model.Article,
                    Sale = model.Sale,
                    New = model.New,
                    Color = model.Color
                };

                foreach (var picture in pictures)
                {
                    var pictureModel = new PictureSneakerModel()
                    {
                        Id = picture.Id,
                        IdModel = picture.IdModel,
                        Main = picture.Main,
                        Href = picture.Href
                    };

                    sneakerModel.Pictures.Add(pictureModel);
                }

                sneakerModels.Add(sneakerModel);
            }

            return sneakerModels;
        }

        private IQueryable<ModelSneaker> Search(SearchModel search)
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
