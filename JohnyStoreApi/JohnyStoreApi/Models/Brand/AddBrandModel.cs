using JohnyStoreApi.Models.Picture;

namespace JohnyStoreApi.Models.Brand
{
    public class AddBrandModel : BrandModel
    {
        public new AddPictureBrandModel Picture { get; set; }
    }
}
