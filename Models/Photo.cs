using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MakeITDigital.Models
{
    [Table("Photo")]
    public partial class Photo
    {
        public Photo()
        {
            Tags = new HashSet<Tag>();
        }

        [Key]
        [Column("PhotoID")]
        public int PhotoId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateUploaded { get; set; }
        [Required]
        [Column("Photo")]
        public byte[] Photo1 { get; set; }
        [Required]
        [StringLength(1000)]
        public string Title { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Photos")]
        public virtual User User { get; set; }
        [InverseProperty("Photo")]
        public virtual Location Location { get; set; }
        [InverseProperty("Photo")]
        public virtual Metum Metum { get; set; }
        [InverseProperty(nameof(Tag.Photo))]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
