using Castle.Components.DictionaryAdapter.Xml;
using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Brand;
using JohnyStoreApi.Services.AdditionalServices;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using JohnyStoreData.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace JohnyStoreApi.Services.DataServices
{
    public class BrandDataService : IBrandDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IPictureBrandDataService _pictureBrandDataService;

        public BrandDataService(
            JohnyStoreContext context,
            IJohnyStoreLogger logger,
            IConfiguration configuration,
            IPictureBrandDataService pictureBrandDataService)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _pictureBrandDataService = pictureBrandDataService;
        }

        /// <summary>
        /// Получение бренда по id
        /// </summary>
        /// <param name="idBrand"></param>
        /// <returns></returns>
        public BrandModel GetBrandById(int idBrand)
        {
            return _context.Brands.First(x => x.Id == idBrand && x.Visible == true).MapToBrandModel(_context, _configuration);
        }

        /// <summary>
        /// Получение всех брендов
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> GetBrands()
        {
            return _context.Brands.Where(x => x.Visible == true).ToList().MapToBrandModels(_context, _configuration)
                ?? new List<BrandModel>();
        }

        /// <summary>
        /// Добавление бренда
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public bool AddBrand(AddBrandModel model)
        {
            if(!(model.Validate()))
                return false;

            using(var transaction = _context.Database.BeginTransaction()) 
            {
                try
                {
                    Brand brand = model.MapToBrand();
                    _context.Brands.Add(brand);

                    _pictureBrandDataService.AddPicture(model.Picture, brand);

                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
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
        /// Редактирование бренда
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditBrand(AddBrandModel model)
        {
            if (!(model.Validate()) || model.Id == 0)
                return false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Brand brand = _context.Brands.First(x => x.Id == model.Id && x.Visible == true) ?? throw new Exception("Бренд не найден");
                    brand.Name = model.Name;

                    _pictureBrandDataService.DeletePicture(brand.Id);
                    _pictureBrandDataService.AddPicture(model.Picture, brand);

                    _context.SaveChanges();
                    transaction.Commit();

                    return true;
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
        /// Удаление бренда(удаление невозможно, если остались кроссовки такого бренда)
        /// </summary>
        /// <param name="idBrand"></param>
        /// <returns></returns>
        public bool DeleteBrand(int idBrand) 
        {
            try
            {
                var sneakers = _context.ModelsSneakers.Where(x => x.Brand.Id == idBrand).ToList();
                if (sneakers.Count > 0)
                    throw new Exception("В коллекции еще присутсвуют кроссовки данного бренда");

                Brand brand = _context.Brands.First(x => x.Id == idBrand) ?? throw new Exception("Бренд не найден");
                brand.Visible = false;

                _pictureBrandDataService.DeletePicture(idBrand);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }
    }
}
