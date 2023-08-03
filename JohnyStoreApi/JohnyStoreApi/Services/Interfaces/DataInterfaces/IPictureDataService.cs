using JohnyStoreApi.Models.Picture;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    public interface IPictureDataService
    {
        bool AddPictures(List<AddPictureSneakerModel> modelPictures, int idModel);
        bool DeletePictures(int idModel);
    }
}
