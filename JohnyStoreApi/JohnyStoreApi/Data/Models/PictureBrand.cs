using JohnyStoreData.Models;

namespace JohnyStoreApi.Data.Models
{
    public class PictureBrand
    {
        public int Id { get; set; }
        public virtual Brand Brand { get; set; }
        public string Href { get; set; }
        public bool Visible { get; set; }
    }
}
