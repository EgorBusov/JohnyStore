namespace JohnyStoreApi.Models.Picture
{
    /// <summary>
    /// Модель добавления кроссовок
    /// </summary>
    public class AddPictureSneakerModel
    {
        public int IdModel { get; set; }
        public bool Main { get; set; }
        public IFormFile File { get; set; }
    }
}
