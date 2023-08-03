namespace JohnyStoreApi.Models.Order
{
    /// <summary>
    /// Модель статуса заказа
    /// </summary>
    public class OrderStatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
