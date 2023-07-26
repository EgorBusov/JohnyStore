using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.Models
{
    /// <summary>
    /// Брэнд кроссовок
    /// </summary>
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
    }
}
