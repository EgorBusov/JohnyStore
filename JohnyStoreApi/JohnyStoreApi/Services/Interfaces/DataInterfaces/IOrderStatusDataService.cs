using JohnyStoreApi.Models.Order;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа со статусами заказов
    /// </summary>
    public interface IOrderStatusDataService
    {
        List<OrderStatusModel> GetOrderStatuses();
        bool AddStatus(OrderStatusModel model);
        bool DeleteStatus(int idStatus);
    }
}
