using JohnyStoreApi.Data.Models;
using JohnyStoreApi.Logging.Interfaces;
using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Services.Interfaces;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using JohnyStoreData.EF;
using JohnyStoreData.Models;

namespace JohnyStoreApi.Services.DataServices
{
    public class PictureBrandDataService : IPictureBrandDataService
    {
        private readonly JohnyStoreContext _context;
        private readonly IConfiguration _configuration;
        private readonly IFileManager _fileManager;

        public PictureBrandDataService(
            JohnyStoreContext context,
            IConfiguration configuration,
            IFileManager fileManager,
            IJohnyStoreLogger logger)
        {
            _context = context;
            _configuration = configuration;
            _fileManager = fileManager;
        }

        /// <summary>
        /// Получение картинки
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stream GetPicture(string path)
        {
            var pathDirectory = _configuration.GetValue<string>("Paths:PathDirectoryPictureForBrand");
            var fullPathDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathDirectory, path);

            return _fileManager.GetFile(fullPathDirectory);
        }

        /// <summary>
        /// Добавление картинок для кроссовок
        /// </summary>
        /// <param name="modelPictures"></param>
        /// <param name="idModel"></param>
        /// <returns></returns>
        public bool AddPicture(AddPictureBrandModel modelPicture, Brand brand)
        {
            var pathDirectory = _configuration.GetValue<string>("Paths:PathDirectoryPictureForBrand");
            var fullPathDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathDirectory);

            PictureBrand pictureBrand = new PictureBrand()
            {
                Brand = brand,
                Href = _fileManager.SaveFile
                (modelPicture.File.OpenReadStream(),
                fullPathDirectory, 
                Path.GetExtension(modelPicture.File.FileName) ),
                Visible = true

            };

            _context.PictureBrands.Add(pictureBrand);
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Удаление картинок относящихся к определенной модели кроссовок
        /// </summary>
        /// <param name="idModel"></param>
        /// <returns></returns>
        public bool DeletePicture(int idBrand)
        {
            var pathDirectory = _configuration.GetValue<string>("Paths:PathDirectoryPictureForBrand");
            var picture = _context.PictureBrands.FirstOrDefault(x => x.Brand.Id == idBrand);

            _fileManager.DeleteFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathDirectory, picture.Href));

            _context.PictureBrands.Remove(picture);
            _context.SaveChanges();

            return true;
        }
    }
}
