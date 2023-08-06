using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Brand;
using JohnyStoreData.EF;
using JohnyStoreData.Models;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace JohnyStoreApi.Services.DataServices
{
    public class BrandService
    {
        private readonly JohnyStoreContext _context;
        private readonly IJohnyStoreLogger _logger;

        public BrandService(
            JohnyStoreContext context,
            IJohnyStoreLogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Получение бренда по id
        /// </summary>
        /// <param name="idBrand"></param>
        /// <returns></returns>
        public BrandModel GetBrandById(int idBrand)
        {
            return _context.Brands.First(x => x.Id == idBrand).MapToBrandModel();
        }

        /// <summary>
        /// Получение всех брендов
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> GetBrands()
        {
            return _context.Brands.Where(x => x.Visible == true).ToList().MapToBrandModels() 
                ?? new List<BrandModel>();
        }

        /// <summary>
        /// Добавление бренда
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public bool AddBrand(BrandModel model)
        {
            try
            {
                Brand brand = model.MapToBrand();

                _context.Brands.Add(brand);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Редактирование бренда
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditBrand(BrandModel model)
        {
            try
            {
                Brand brand = _context.Brands.First(x => x.Id == model.Id) ?? throw new Exception("Бренд не найден");
                brand.Name = model.Name;

                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.ErrorLog(ex.Message);
                return false;
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
                var sneakers = _context.ModelsSneakers.Where(x => x.IdBrand == idBrand).ToList();
                if (sneakers.Count > 0)
                    throw new Exception("В коллекции еще присутсвуют кроссовки данного бренда");

                Brand brand = _context.Brands.First(x => x.Id == idBrand) ?? throw new Exception("Бренд не найден");
                brand.Visible = false;

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
