using JohnyStoreApi.Models.Brand;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа с брендами кроссовок
    /// </summary>
    public interface IBrandDataService
    {
        BrandModel GetBrandById(int idBrand);
        List<BrandModel> GetBrands();
        bool AddBrand(BrandModel model);
        bool DeleteBrand(int idBrand);
        bool EditBrand(BrandModel model);
    }
}
