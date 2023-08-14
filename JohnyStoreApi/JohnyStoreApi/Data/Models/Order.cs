using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public virtual Sneaker Model { get; set; }
        public decimal SizeFoot { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual OrderStatus Status { get; set; }
        public bool Visible { get; set; }
    }
}
