using System.ComponentModel.DataAnnotations;

namespace DatingAppFS.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [StringLength(10,MinimumLength =6)]
        public string password { get; set; }
    }
}
