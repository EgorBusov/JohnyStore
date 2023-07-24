using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.Models
{
    internal class ModelSneaker
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// true - man, false - woman
        /// </summary>
        public bool Gender { get; set; }
        public bool WinterOrSummer { get; set; }
        public int IdStyle { get; set; }
        /// <summary>
        /// Артикул кроссовок
        /// </summary>
        public string Article { get; set; }
        /// <summary>
        /// Действует ли скидка
        /// </summary>
        public bool Sale { get; set; }
        public bool New { get; set; }
        public string Color { get; set; }
        public bool Visible { get; set; }
    }
}
