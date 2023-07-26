using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.Models
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public bool Visible { get; set; }
    }
}
