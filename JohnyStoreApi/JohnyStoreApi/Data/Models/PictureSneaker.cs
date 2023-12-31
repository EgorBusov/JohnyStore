﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.Models
{
    /// <summary>
    /// Картинка к модели кроссовок
    /// </summary>
    public class PictureSneaker
    {
        public int Id { get; set; }
        public virtual Sneaker Model { get; set; }
        /// <summary>
        /// Является ли картинка основной
        /// </summary>
        public bool Main { get; set; }
        public string Href { get; set; }
        public bool Visible { get; set; }
    }
}
