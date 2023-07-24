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
    internal class Order
    {
        public int Id { get; set; }
        public int IdModel { get; set; }
        public decimal SizeFoot { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IdStatus { get; set; }
        public bool Visible { get; set; }
    }
}
