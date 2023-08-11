using JohnyStoreApi.Models;
using JohnyStoreApi.Models.Availability;
using JohnyStoreApi.Models.Brand;
using JohnyStoreApi.Models.Order;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreApi.Models.Style;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
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
        public static List<SneakerModel> MapToSneakerModels(this List<Sneaker> modelSneakers, 
                                                                JohnyStoreContext context, 
                                                                IConfiguration configuration)
        {
            List<SneakerModel> sneakerModels = new List<SneakerModel>();

            if (modelSneakers.Count == 0 || modelSneakers == null)
                return sneakerModels;

            foreach (var model in modelSneakers)
            {
                SneakerModel sneakerModel = model.MapToSneakerModel(context, configuration);

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
        public static SneakerModel MapToSneakerModel(this Sneaker modelSneaker, JohnyStoreContext context, IConfiguration configuration)
        {
            if (modelSneaker == null)
                return new SneakerModel()
                {
                    Pictures = new List<PictureSneakerModel>()
                };

            Brand brand = context.Brands.First(x => x.Id == modelSneaker.IdBrand);
            List<PictureSneakerModel> pictures = context.PictureSneakers
                .Where(x => x.IdModel == modelSneaker.Id && x.Visible == true)
                .ToList().MapToPictureSneakerModels(configuration);
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
                Pictures = pictures,
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
                Href = Path.GetFileName(pictureSneaker.Href),
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

        /// <summary>
        /// Приводит PictureSneaker к PictureSneakerModel
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public static PictureSneakerModel MapToPictureSneakerModel(this PictureSneaker picture, IConfiguration configuration)
        {
            string url = configuration.GetValue<string>("BaseUrl:Url");
            string fullUrl = $"{url}/Picture/GetPicture/{picture.Href}";

            return new PictureSneakerModel()
            {
                Id = picture.Id,
                IdModel = picture.IdModel,
                Href = fullUrl,
                Main = picture.Main
            };
        }

        /// <summary>
        /// Приводит коллекцию PictureSneaker к коллекции PictureSneakerModel
        /// </summary>
        /// <param name="pictures"></param>
        /// <returns></returns>
        public static List<PictureSneakerModel> MapToPictureSneakerModels(this List<PictureSneaker> pictures, IConfiguration configuration)
        {
            var models = new List<PictureSneakerModel>();

            foreach (var picture in pictures)
            {
                var model = picture.MapToPictureSneakerModel(configuration);
                models.Add(model);
            }

            return models;
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
        public static AvailabilityModel MapToAvailabilityModel(this Availability availability, 
                                                                    JohnyStoreContext context, 
                                                                    IConfiguration configuration)
        {
            AvailabilityModel model = new AvailabilityModel()
            {
                Id = availability.Id,
                Model = context.ModelsSneakers.First(x => x.Id == availability.IdModel).MapToSneakerModel(context, configuration),
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

        /// <summary>
        /// Приводит колекцию AvailabilityStatus к коллекции AvailabilityStatusModel
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<AvailabilityStatusModel> MapToAvailabilityStatusModel(this List<AvailabilityStatus> status) 
        {
            var models = new List<AvailabilityStatusModel>();
            foreach (var item in status)
            {
                var model = item.MapToAvailabiltyStatusModel();
                models.Add(model);
            }
            return models;
        }

        /// <summary>
        /// Приводит AvailabilityStatusModel к AvailabilityStatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static AvailabilityStatus MapToAvailabilityStatus(this AvailabilityStatusModel model)
        {
            return new AvailabilityStatus()
            {
                Id = model.Id,
                Name = model.Name,
                Visible = true
            };
        }

        #endregion

        #region Brand

        /// <summary>
        /// Приводит коллекцию Brand к коллекции BrandModel
        /// </summary>
        /// <param name="brands"></param>
        /// <returns></returns>
        public static List<BrandModel> MapToBrandModels(this List<Brand> brands)
        {
            List<BrandModel> brandModels = new List<BrandModel>();

            foreach (Brand brand in brands)
            {
                BrandModel brandModel = brand.MapToBrandModel();
                brandModels.Add(brandModel);
            }
            return brandModels;
        }

        /// <summary>
        /// Приводит Brand к BrandModel
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static BrandModel MapToBrandModel(this Brand brand)
        {
            return new BrandModel()
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }

        /// <summary>
        /// Приводит BrandModel к Brand
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Brand MapToBrand(this BrandModel model)
        {
            Brand brand = new Brand()
            {
                Id= model.Id,
                Name = model.Name,
                Visible = true
            };

            return brand;
        }

        #endregion

        #region Order

        /// <summary>
        /// Приводит коллекцию OrderStatus к коллекции OrderStatusModel
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<OrderModel> MapToOrderModels(this List<Order> orders, JohnyStoreContext context, IConfiguration configuration)
        {
            var models = new List<OrderModel>();

            foreach (Order order in orders)
            {
                OrderModel model = order.MapToOrderModel(context, configuration);
                models.Add(model);
            }

            return models;
        }

        /// <summary>
        /// Приводит Order к OrderModel
        /// </summary>
        /// <param name="order"></param>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static OrderModel MapToOrderModel(this Order order, JohnyStoreContext context, IConfiguration configuration)
        {
            OrderModel orderModel = new OrderModel()
            {
                Id = order.Id,
                Email = order.Email,
                Phone = order.Phone,
                SizeFoot = order.SizeFoot,
                Model = context.ModelsSneakers.First(x => x.Id == order.IdModel).MapToSneakerModel(context, configuration),
                Status = context.OrderStatuses.First(x => x.Id == order.IdStatus).MapToOrderStatusModel()
            };

            return orderModel;
        }

        /// <summary>
        /// Приводит OrderModel к Order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Order MapToOrder(this OrderModel model)
        {
            Order order = new Order()
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                SizeFoot = model.SizeFoot,
                IdModel = model.Model.Id,
                IdStatus = model.Status.Id,
                Visible = true
            };

            return order;
        }

        /// <summary>
        /// Приводит коллекцию OrderStatus к коллекции OrderStatusModel 
        /// </summary>
        /// <param name="statuses"></param>
        /// <returns></returns>
        public static List<OrderStatusModel> MapToOrderStatusModels(this List<OrderStatus> statuses) 
        {
            var models = new List<OrderStatusModel>();

            foreach (var status in statuses)
            {
                var model = status.MapToOrderStatusModel();
                models.Add(model);
            }

            return models;
        }

        /// <summary>
        /// Приводит OrderStatus к OrderStatusModel
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static OrderStatusModel MapToOrderStatusModel(this OrderStatus status)
        {
            OrderStatusModel model = new OrderStatusModel()
            {
                Id = status.Id,
                Name = status.Name,
                Position = status.Position
            };

            return model;
        }

        /// <summary>
        /// Приводит OrderStatusModel к OrderStatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static OrderStatus MapToOrderStatus(this OrderStatusModel model)
        {
            OrderStatus status = new OrderStatus()
            {
                Id = model.Id,
                Name = model.Name,
                Position = model.Position,
                Visible = true
            };

            return status;
        }

        #endregion
    }
}
