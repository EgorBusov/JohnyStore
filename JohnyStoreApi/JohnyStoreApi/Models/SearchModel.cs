namespace JohnyStoreApi.Models
{
    /// <summary>
    /// модель фильтра для поиска кроссовок
    /// </summary>
    public class SearchModel
    {
        public int? BrandId { get; set; }
        public string? Name { get; set; }
        public int? PriceMin { get; set; }
        public int? PriceMax { get; set; }
        public bool? Geneder { get; set; }
        public bool? WinterOrSummer { get; set; }
        public int? StyleId { get; set; }
        public string? Article { get; set; }
        public bool? Sale { get; set; }
        public bool? New { get; set; }
    }
}
