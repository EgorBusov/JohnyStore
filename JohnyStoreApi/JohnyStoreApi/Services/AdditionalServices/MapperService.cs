﻿using JohnyStoreApi.Data.Models;
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

namespace JohnyStoreApi.Services.AdditionalServices
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

            List<PictureSneakerModel> pictures = context.PictureSneakers
                .Where(x => x.Model.Id == modelSneaker.Id && x.Visible == true)
                .ToList().MapToPictureSneakerModels(configuration);

            SneakerModel sneakerModel = new SneakerModel()
            {
                Id = modelSneaker.Id,
                Brand = modelSneaker.Brand.MapToBrandModel(context, configuration),
                Name = modelSneaker.Name,
                Pictures = pictures,
                Price = modelSneaker.Price,
                Description = modelSneaker.Description,
                Gender = modelSneaker.Gender,
                WinterOrSummer = modelSneaker.WinterOrSummer,
                Style = new StyleModel()
                {
                    Id = modelSneaker.Style.Id,
                    Name = modelSneaker.Style.Name
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
        public static Sneaker MapToSneaker(this AddSneakerModel addSneakerModel, JohnyStoreContext context)
        {
            Brand brand = context.Brands.FirstOrDefault(x => x.Id == addSneakerModel.Brand) ?? new Brand();
            Style style = context.Styles.FirstOrDefault(x => x.Id == addSneakerModel.Style) ?? new Style();

            Sneaker sneaker = new Sneaker()
            {
                Id = addSneakerModel.Id,
                Brand = brand,
                Name = addSneakerModel.Name,
                Price = addSneakerModel.Price,
                Description = addSneakerModel.Description,
                Gender = addSneakerModel.Gender,
                WinterOrSummer = addSneakerModel.WinterOrSummer,
                Style = style,
                Article = addSneakerModel.Article,
                Sale = addSneakerModel.Sale,
                New = addSneakerModel.New,
                Color = addSneakerModel.Color,
                Visible = true
            };

            return sneaker;
        }

        /// <summary>
        /// Приводит SneakerModel к Sneaker
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Sneaker MapToSneaker(this SneakerModel model, JohnyStoreContext context)
        {
            Style style = context.Styles.FirstOrDefault(x => x.Id == model.Style.Id) ?? new Style();

            Sneaker sneaker = new Sneaker()
            {
                Id = model.Id,
                Brand = model.Brand.MapToBrand(),
                Style = style,
                WinterOrSummer = model.WinterOrSummer,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Gender = model.Gender,
                Article = model.Article,
                Sale = model.Sale,
                New = model.New,
                Color = model.Color,
                Visible = true
            };

            return sneaker;
        }
        #endregion

        #region Picture

        /// <summary>
        /// Приводит PictureSneaker к PictureSneakerModel
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public static PictureSneakerModel MapToPictureSneakerModel(this PictureSneaker picture, IConfiguration configuration)
        {
            string url = configuration.GetValue<string>("BaseUrl:Url");
            string fullUrl = $"{url}/Picture/GetSneakerPicture/{picture.Href}";

            return new PictureSneakerModel()
            {
                Id = picture.Id,
                IdModel = picture.Model.Id,
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
        public static Availability MapToAvailability(this AddAvailabilityModel model, JohnyStoreContext context)
        {
            var statuses = context.AvailabilityStatuses.Where(x => x.Visible == true).ToList();

            Availability availability = new Availability()
            {
                Id = model.Id,
                Model = context.ModelsSneakers.FirstOrDefault(x => x.Id == model.ModelId) 
                ?? throw new Exception("Модель не найдена"),
                Status35 = statuses.FirstOrDefault(x => x.Id == model.Status35) 
                ?? throw new Exception("Статус не найден"),
                Status36 = statuses.FirstOrDefault(x => x.Id == model.Status36)
                ?? throw new Exception("Статус не найден"),
                Status37 = statuses.FirstOrDefault(x => x.Id == model.Status37)
                ?? throw new Exception("Статус не найден"),
                Status38 = statuses.FirstOrDefault(x => x.Id == model.Status38)
                ?? throw new Exception("Статус не найден"),     
                Status39 = statuses.FirstOrDefault(x => x.Id == model.Status39)
                ?? throw new Exception("Статус не найден"),
                Status40 = statuses.FirstOrDefault(x => x.Id == model.Status40)
                ?? throw new Exception("Статус не найден"),
                Status41 = statuses.FirstOrDefault(x => x.Id == model.Status41)
                ?? throw new Exception("Статус не найден"),
                Status42 = statuses.FirstOrDefault(x => x.Id == model.Status42)
                ?? throw new Exception("Статус не найден"),
                Status43 = statuses.FirstOrDefault(x => x.Id == model.Status43)
                ?? throw new Exception("Статус не найден"),
                Status44 = statuses.FirstOrDefault(x => x.Id == model.Status44)
                ?? throw new Exception("Статус не найден"),
                Status45 = statuses.FirstOrDefault(x => x.Id == model.Status45)
                ?? throw new Exception("Статус не найден"),
                Status46 = statuses.FirstOrDefault(x => x.Id == model.Status46)
                ?? throw new Exception("Статус не найден"),
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
                                                                    JohnyStoreContext context)
        {
            AvailabilityModel model = new AvailabilityModel()
            {
                Id = availability.Id,
                ModelId = availability.Model.Id,
                Status35 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status35.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status36 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status36.Id)?.MapToAvailabiltyStatusModel()
                ?? new AvailabilityStatusModel(),
                Status37 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status37.Id)?.MapToAvailabiltyStatusModel()
                ?? new AvailabilityStatusModel(),
                Status38 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status38.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status39 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status39.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status40 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status40.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status41 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status41.Id)?.MapToAvailabiltyStatusModel()
                ?? new AvailabilityStatusModel(),
                Status42 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status42.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status43 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status43.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status44 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status44.Id)?.MapToAvailabiltyStatusModel()
                ?? new AvailabilityStatusModel(),
                Status45 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status45.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
                Status46 = context.AvailabilityStatuses.FirstOrDefault(x => x.Id == availability.Status46.Id)?.MapToAvailabiltyStatusModel() 
                ?? new AvailabilityStatusModel(),
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
        public static List<BrandModel> MapToBrandModels(this List<Brand> brands, JohnyStoreContext context, IConfiguration configuration)
        {
            List<BrandModel> brandModels = new List<BrandModel>();

            foreach (Brand brand in brands)
            {
                BrandModel brandModel = brand.MapToBrandModel(context, configuration);
                brandModels.Add(brandModel);
            }
            return brandModels;
        }

        /// <summary>
        /// Приводит Brand к BrandModel
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static BrandModel MapToBrandModel(this Brand brand, JohnyStoreContext context, IConfiguration configuration)
        {
            var picture = context.PictureBrands.FirstOrDefault(x => x.Brand.Id == brand.Id && x.Visible != false) 
                ?? new PictureBrand();

            return new BrandModel()
            {
                Id = brand.Id,
                Name = brand.Name,
                Picture = picture.MapToPictureBrandModel(configuration)
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
                Id = model.Id,
                Name = model.Name,
                Visible = true
            };

            return brand;
        }

        /// <summary>
        /// Приводит AddBrandModel к Brand
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Brand MapToBrand(this AddBrandModel model)
        {
            Brand brand = new Brand()
            {
                Id = model.Id,
                Name = model.Name,
                Visible = true
            };

            return brand;
        }

        /// <summary>
        /// Приводит PictureBrand к PictureBrandModel
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static PictureBrandModel MapToPictureBrandModel(this PictureBrand picture, IConfiguration configuration)
        {
            string url = configuration.GetValue<string>("BaseUrl:Url");
            string fullUrl = $"{url}/Picture/GetBrandPicture/{picture.Href}";

            PictureBrandModel model = new PictureBrandModel()
            {
                Id = picture.Id,
                IdBrand = picture.Brand.Id,
                Href = fullUrl
            };

            return model;
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
                Model = context.ModelsSneakers.FirstOrDefault(x => x.Id == order.Model.Id)?.MapToSneakerModel(context, configuration) 
                ?? new SneakerModel(),
                Status = context.OrderStatuses.FirstOrDefault(x => x.Id == order.Status.Id)?.MapToOrderStatusModel() 
                ?? new OrderStatusModel(),
            };

            return orderModel;
        }

        /// <summary>
        /// Приводит OrderModel к Order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Order MapToOrder(this OrderModel model, JohnyStoreContext context)
        {
            OrderStatus status = context.OrderStatuses.FirstOrDefault(x => x.Id == model.Status.Id) ?? new OrderStatus();

            Order order = new Order()
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                SizeFoot = model.SizeFoot,
                Model = model.Model.MapToSneaker(context),
                Status = status,
                Visible = true
            };

            return order;
        }

        /// <summary>
        /// Приводит AddOrderModel к Order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Order MapToOrder(this AddOrderModel model, JohnyStoreContext context)
        {
            OrderStatus status = context.OrderStatuses.FirstOrDefault(x => x.Id == model.Status) ?? new OrderStatus();

            Order order = new Order()
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                SizeFoot = model.SizeFoot,
                Model = context.ModelsSneakers.FirstOrDefault(x => x.Id == model.ModelId) ?? new Sneaker(),
                Status = status,
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

        #region Style

        /// <summary>
        /// Приводит коллекцию Style к коллекции StyleModel
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static List<StyleModel> MapToStyleModels(this List<Style> styles)
        {
            var models = new List<StyleModel>();

            foreach (var style in styles)
            {
                models.Add(style.MapToStyleModel());
            }

            return models;
        }

        /// <summary>
        /// Приводит Style к StyleModel
        /// </summary>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static StyleModel MapToStyleModel(this Style style)
        {
            StyleModel model = new StyleModel()
            {
                Id = style.Id,
                Name = style.Name,
            };

            return model;
        }

        /// <summary>
        /// Приводит StyleModel к Style
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Style MapToStyle(this StyleModel model)
        {
            Style style = new Style()
            {
                Id = model.Id,
                Name = model.Name,
                Visible = true
            };

            return style;
        }

        #endregion
    }
}
