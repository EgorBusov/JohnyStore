namespace JohnyStoreApi.Models.Picture
{
    public class AddPictureSneakerModel
    {
        public int IdModel { get; set; }    
        public bool Main { get; set; }
        public IFormFile File { get; set; }
    }
}
