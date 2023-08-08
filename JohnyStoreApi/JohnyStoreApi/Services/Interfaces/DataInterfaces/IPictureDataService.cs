using JohnyStoreApi.Models.Picture;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа с картинками для кроссовок
    /// </summary>
    public interface IPictureDataService
    {
        Stream GetPicture(string path);
        bool AddPictures(List<AddPictureSneakerModel> modelPictures, int idModel);
        bool DeletePictures(int idModel);
    }
}
