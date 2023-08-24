using JohnyStoreApi.Models.Picture;
using JohnyStoreData.Models;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    public interface IPictureBrandDataService
    {
        Stream GetPicture(string path);
        bool AddPicture(AddPictureBrandModel modelPicture, Brand brand);
        bool DeletePicture(int idBrand);
    }
}
