using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MakeITDigital.Models
{
    [Table("User")]
    [Index(nameof(EmailAddress), Name = "unique_email", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Photos = new HashSet<Photo>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SignUpDate { get; set; }

        [InverseProperty(nameof(Photo.User))]
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
