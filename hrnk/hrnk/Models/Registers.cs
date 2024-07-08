using System.ComponentModel.DataAnnotations;

namespace hrnk.Models
{
    public class Registers
    {
        [Required]
        public string username {  get; set; }
        [Required]
        public string password { get; set; }
        public string confirmpassword  { get; set; }
    }
}
