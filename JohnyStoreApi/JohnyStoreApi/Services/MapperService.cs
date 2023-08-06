using JohnyStoreApi.Models;
using JohnyStoreApi.Models.Availability;
using JohnyStoreApi.Models.Brand;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreApi.Models.Style;
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

        /// <summary>
        /// Приводит AddSneakerModel к Sneaker
        /// </summary>
        /// <param name="addSneakerModel"></param>
        /// <returns></returns>
        public static Sneaker MapToSneaker(this AddSneakerModel addSneakerModel)
        {
            Sneaker sneaker = new Sneaker()
            {
                Id = addSneakerModel.Id,
                IdBrand = addSneakerModel.Brand,
                Name = addSneakerModel.Name,
                Price = addSneakerModel.Price,
                Description = addSneakerModel.Description,
                Gender = addSneakerModel.Gender,
                WinterOrSummer = addSneakerModel.WinterOrSummer,
                IdStyle = addSneakerModel.Style,
                Article = addSneakerModel.Article,
                Sale = addSneakerModel.Sale,
                New = addSneakerModel.New,
                Color = addSneakerModel.Color,
                Visible = true
            };

            return sneaker;
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

        #region Availability

        /// <summary>
        /// Приводит AvailabilityModel к Availablity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Availability MapToAvailability(this AvailabilityModel model) 
        {
            Availability availability = new Availability()
            {
                Id = model.Id,
                IdModel = model.Model.Id,
                Status35 = model.Status35.Id,
                Status36 = model.Status36.Id,
                Status37 = model.Status37.Id,
                Status38 = model.Status38.Id,
                Status39 = model.Status39.Id,
                Status40 = model.Status40.Id,
                Status41 = model.Status41.Id,
                Status42 = model.Status42.Id,
                Status43 = model.Status43.Id,
                Status44 = model.Status44.Id,
                Status45 = model.Status45.Id,
                Status46 = model.Status46.Id,
                Visible = true

            };

            return availability;
        }

        /// <summary>
        /// Приводит Availabilty к AvailabilityModel
        /// </summary>
        /// <param name="availability"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static AvailabilityModel MapToAvailabilityModel(this Availability availability, JohnyStoreContext context)
        {
            AvailabilityModel model = new AvailabilityModel()
            {
                Id = availability.Id,
                Model = context.ModelsSneakers.First(x => x.Id == availability.IdModel).MapToSneakerModel(context),
                Status35 = context.AvailabilityStatuses.First(x => x.Id == availability.Status35).MapToAvailabiltyStatusModel(),
                Status36 = context.AvailabilityStatuses.First(x => x.Id == availability.Status36).MapToAvailabiltyStatusModel(),
                Status37 = context.AvailabilityStatuses.First(x => x.Id == availability.Status37).MapToAvailabiltyStatusModel(),
                Status38 = context.AvailabilityStatuses.First(x => x.Id == availability.Status38).MapToAvailabiltyStatusModel(),
                Status39 = context.AvailabilityStatuses.First(x => x.Id == availability.Status39).MapToAvailabiltyStatusModel(),
                Status40 = context.AvailabilityStatuses.First(x => x.Id == availability.Status40).MapToAvailabiltyStatusModel(),
                Status41 = context.AvailabilityStatuses.First(x => x.Id == availability.Status41).MapToAvailabiltyStatusModel(),
                Status42 = context.AvailabilityStatuses.First(x => x.Id == availability.Status42).MapToAvailabiltyStatusModel(),
                Status43 = context.AvailabilityStatuses.First(x => x.Id == availability.Status43).MapToAvailabiltyStatusModel(),
                Status44 = context.AvailabilityStatuses.First(x => x.Id == availability.Status44).MapToAvailabiltyStatusModel(),
                Status45 = context.AvailabilityStatuses.First(x => x.Id == availability.Status45).MapToAvailabiltyStatusModel(),
                Status46 = context.AvailabilityStatuses.First(x => x.Id == availability.Status46).MapToAvailabiltyStatusModel(),
            };

            return model;
        }

        /// <summary>
        /// Приводит AvailabilityStatus к AvailabiltyStatusModel
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static AvailabilityStatusModel MapToAvailabiltyStatusModel(this AvailabilityStatus status)
        {
            var model = new AvailabilityStatusModel()
            {
                Id = status.Id,
                Name = status.Name
            };

            return model;
        }

        #endregion
    }
}
