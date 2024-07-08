using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrnk.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public long userid { get; set; }

        [Required, MaxLength(50)]
        [Column("username")]
        public string username { get; set; }

        [Required]
        [Column("hash_password", TypeName = "binary(255)")] // Adjust size as necessary
        public byte[] hash_password { get; set; }

        
        [Required, MaxLength(50)]
        [Column("role_id")]
        public int role_id { get; set; }

        [Column("user_create_at")]
        public DateTime? user_create_at { get; set; }

        [Column("user_create_by")]
        public string user_create_by { get; set; }

        [Column("user_update_at")]
        public DateTime? user_update_at { get; set; }

        [Column("user_update_by")]
        public string user_update_by { get; set; }
    }
}
