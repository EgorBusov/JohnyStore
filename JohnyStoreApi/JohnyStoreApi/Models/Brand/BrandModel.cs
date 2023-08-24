using JohnyStoreApi.Models.Picture;

namespace JohnyStoreApi.Models.Brand
{
    public class BrandModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PictureBrandModel Picture { get; set; }
    }
}
