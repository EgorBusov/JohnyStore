using JohnyStoreApi.Models.Sneaker;
using JohnyStoreApi.Models;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа с кроссовками
    /// </summary>
    public interface ISneakerDataService
    {
        List<SneakerModel> GetSneakers(SearchModel? search);
        SneakerModel GetSneakerByid(int id);
        bool AddSneaker(AddSneakerModel model);
        bool EditSneaker(AddSneakerModel model);
        bool DeleteSneaker(int idModel);
    }
}
