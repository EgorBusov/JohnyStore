using JohnyStoreApi.Models.Picture;

namespace JohnyStoreApi.Models.Sneaker
{
    /// <summary>
    /// Модель добавления кроссовок
    /// </summary>
    public class AddSneakerModel : SneakerModel
    {
        public new int Brand { get; set; }
        public new List<IFormFile> Pictures { get; set; }
        public new int Style { get; set; }
    }
}
