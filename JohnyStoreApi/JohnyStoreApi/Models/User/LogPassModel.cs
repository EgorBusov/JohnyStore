using System.ComponentModel.DataAnnotations;

namespace JohnyStoreApi.Models.User
{
    public class LogPassModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
