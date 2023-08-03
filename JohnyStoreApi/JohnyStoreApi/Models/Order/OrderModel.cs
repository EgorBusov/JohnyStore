using JohnyStoreApi.Models.Sneaker;

namespace JohnyStoreApi.Models.Order
{
    /// <summary>
    /// Модель заказа
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }
        public SneakerModel Model { get; set; }
        public decimal SizeFoot { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public OrderStatusModel Status { get; set; }
    }
}
