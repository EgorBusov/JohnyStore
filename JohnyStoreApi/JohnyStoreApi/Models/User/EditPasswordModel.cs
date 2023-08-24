using System.ComponentModel.DataAnnotations;

namespace JohnyStoreApi.Models.User
{
    public class EditPasswordModel : LogPassModel
    {
        [Required]
        public string NewPassword { get; set; }
    }
}
