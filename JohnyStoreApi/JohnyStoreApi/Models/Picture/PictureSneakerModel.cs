﻿namespace JohnyStoreApi.Models.Picture
{
    /// <summary>
    /// Картинка модели кроссовок
    /// </summary>
    public class PictureSneakerModel
    {
        public int Id { get; set; }
        public int IdModel { get; set; }
        /// <summary>
        /// Является ли картинка основной
        /// </summary>
        public bool Main { get; set; }
        public string Href { get; set; }
    }
}
