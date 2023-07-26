namespace JohnyStoreApi.Models
{
    /// <summary>
    /// модель фильтра для поиска кроссовок
    /// </summary>
    public class SearchModel
    {
        public int ModelId { get; set; }
        public int? BrandId { get; set; }
        public string? Name { get; set; }
        public int? PriceMin { get; set; }
        public int? PriceMax { get; set; }
        /// <summary>
        /// values: man or wooman
        /// </summary>
        public string? Geneder { get; set; }
        /// <summary>
        /// values: winter or summer
        /// </summary>
        public string? WinterOrSummer { get; set; }
        public int? StyleId { get; set; }
        public string? Article { get; set; }
        public bool? Sale { get; set; }
        public bool? New { get; set; }
    }
}
