namespace JohnyStoreApi.Models
{
    public class SneakerModel
    {
        public int Id { get; set; }
        public BrandModel Brand { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Список картинок
        /// </summary>
        public List<PictureSneakerModel> Pictures { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// true - man, false - woman
        /// </summary>
        public bool Gender { get; set; }
        public bool WinterOrSummer { get; set; }
        public StyleModel Style { get; set; }
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
