using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Manager.Entities
{
    [Table("tbl_user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column("firstname")]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Column("lastname")]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Column("emailid")]
        [MaxLength(200)]
        public string EmailId { get; set; }

        [Column("password")]
        [DataType(DataType.Password)]
        [MaxLength(200)]
        public string Password { get; set; }

        [Column("status")]
        [MaxLength(200)]
        public string Status { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }
    }
}
