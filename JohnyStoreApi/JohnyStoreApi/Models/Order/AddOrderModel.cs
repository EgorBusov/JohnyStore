using JohnyStoreApi.Models.Sneaker;

namespace JohnyStoreApi.Models.Order
{
    public class AddOrderModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int SizeFoot { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
    }
}
