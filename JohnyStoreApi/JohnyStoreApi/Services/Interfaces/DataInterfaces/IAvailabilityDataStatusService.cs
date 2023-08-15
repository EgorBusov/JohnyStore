using JohnyStoreApi.Models.Availability;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа со статусами наличия кроссовок
    /// </summary>
    public interface IAvailabilityDataStatusService
    {
        List<AvailabilityStatusModel> GetAvailabilityStatuses();
        bool AddAvailabilityStatus(AvailabilityStatusModel model);
        bool DeleteAvailabilityStatus(int availabilityId);
    }
}
