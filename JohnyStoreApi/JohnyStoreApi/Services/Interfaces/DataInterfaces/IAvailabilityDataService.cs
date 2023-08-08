using JohnyStoreApi.Models.Availability;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа с информацией о наличии кроссовок
    /// </summary>
    public interface IAvailabilityDataService : IAvailabilityDataStatusService
    {
        AvailabilityModel GetAvailability(int idSneakerModel);
        bool AddAvailability(AvailabilityModel model);
        bool EditAvailability(AvailabilityModel model);
        bool DeleteAvailability(int availabilityId);
    }
}
