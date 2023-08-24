using JohnyStoreApi.Models.Picture;
using JohnyStoreData.Models;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа с картинками для кроссовок
    /// </summary>
    public interface IPictureSneakerDataService
    {
        Stream GetPicture(string path);
        bool AddPictures(List<AddPictureSneakerModel> modelPictures, Sneaker model);
        bool DeletePictures(int idModel);
    }
}
