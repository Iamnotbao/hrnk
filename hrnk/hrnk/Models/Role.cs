using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hrnk.Models
{
    [Table("role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int role_id { get; set; }

        [Required, MaxLength(50)]
        [Column("role_name", TypeName = "nchar(10)")]
        public string role_name { get; set; }

    }
}