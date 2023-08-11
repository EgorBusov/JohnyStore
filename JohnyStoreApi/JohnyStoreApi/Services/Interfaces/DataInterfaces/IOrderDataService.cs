using JohnyStoreApi.Models.Order;

namespace JohnyStoreApi.Services.Interfaces.DataInterfaces
{
    /// <summary>
    /// Работа с заказами
    /// </summary>
    public interface IOrderDataService : IOrderStatusDataService
    {
        OrderModel GetOrderById(int id);
        List<OrderModel> GetOrders();
        bool NextStatusOrder(int idOrder);
        bool AddOrder(OrderModel model);
        bool DeleteOrder(int idOrder);
    }
}
