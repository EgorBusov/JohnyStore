using JohnyStoreApi.Models;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreData.EF;
using JohnyStoreData.Models;
using Microsoft.EntityFrameworkCore;

namespace JohnyStoreApi.Services
{
    /// <summary>
    /// Мапинг
    /// </summary>
    public static class MapperService
    {
        #region Sneaker

        /// <summary>
        /// Проиводит коллекцию Sneaker к SneakerModel
        /// </summary>
        /// <param name="modelSneakers"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<SneakerModel> MapToSneakerModels(this List<Sneaker> modelSneakers, JohnyStoreContext context)
        {
            List<SneakerModel> sneakerModels = new List<SneakerModel>();

            if (modelSneakers.Count == 0 || modelSneakers == null)
                return sneakerModels;

            foreach (var model in modelSneakers)
            {
                SneakerModel sneakerModel = model.MapToSneakerModel(context);

                sneakerModels.Add(sneakerModel);
            }

            return sneakerModels;
        }

        /// <summary>
        /// Приводит Sneaker к SneakerModel
        /// </summary>
        /// <param name="modelSneaker"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static SneakerModel MapToSneakerModel(this Sneaker modelSneaker, JohnyStoreContext context)
        {
            if (modelSneaker == null)
                return new SneakerModel()
                {
                    Pictures = new List<PictureSneakerModel>()
                };

            Brand brand = context.Brands.First(x => x.Id == modelSneaker.IdBrand);
            List<PictureSneaker> pictures = context.PictureSneakers.Where(x => x.IdModel == modelSneaker.Id).ToList();
            Style style = context.Styles.First(x => x.Id == modelSneaker.IdStyle);

            SneakerModel sneakerModel = new SneakerModel()
            {
                Id = modelSneaker.Id,
                Brand = new BrandModel()
                {
                    Id = brand.Id,
                    Name = brand.Name
                },
                Name = modelSneaker.Name,
                Pictures = new List<PictureSneakerModel>(),
                Price = modelSneaker.Price,
                Description = modelSneaker.Description,
                Gender = modelSneaker.Gender,
                WinterOrSummer = modelSneaker.WinterOrSummer,
                Style = new StyleModel()
                {
                    Id = style.Id,
                    Name = style.Name
                },
                Article = modelSneaker.Article,
                Sale = modelSneaker.Sale,
                New = modelSneaker.New,
                Color = modelSneaker.Color
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

            return sneakerModel;
        }


        public static Sneaker MapToSneaker(this SneakerModel sneakerModel)
        {
            Sneaker sneaker = new Sneaker()
            {
                Id = sneakerModel.Id,
                IdBrand = 
                Name = sneakerModel.Name,

            }
        }
        #endregion

        #region Picture

        /// <summary>
        /// Приводит PictureSneakerModel к PictureSneaker
        /// </summary>
        /// <param name="pictureSneaker"></param>
        /// <returns></returns>
        public static PictureSneaker MapToPictureSneaker(this PictureSneakerModel pictureSneaker)
        {
            if(pictureSneaker == null)
                return new PictureSneaker();

            PictureSneaker picture = new PictureSneaker()
            {
                Id = pictureSneaker.Id,
                IdModel = pictureSneaker.IdModel,
                Href = pictureSneaker.Href,
                Main = pictureSneaker.Main,
                Visible = true
            };

            return picture;
        }

        /// <summary>
        /// Приводит коллекцию PictureSneakerModel к коллекции PictureSneaker
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static List<PictureSneaker> MapToPictureSneakers(this List<PictureSneakerModel> models)
        {
            List<PictureSneaker> pictures = new List<PictureSneaker>();

            if (models.Count == 0 || models == null)
                return pictures;

            foreach (var model in models)
            {
                var picture = model.MapToPictureSneaker();
                pictures.Add(picture);
            }

            return pictures;
        }

        #endregion
    }
}
