// Models/LoginViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace hrnk.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
