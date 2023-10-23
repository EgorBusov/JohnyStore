using JohnyStoreApi.Models.Picture;

namespace JohnyStoreApi.Models.Brand
{
    public class AddBrandModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddPictureBrandModel Picture { get; set; }
    }
}
