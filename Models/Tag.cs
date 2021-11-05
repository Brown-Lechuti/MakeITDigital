using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MakeITDigital.Models
{
    [Table("Tag")]
    public partial class Tag
    {
        [Column("PhotoID")]
        public int PhotoId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string TaggedEmail { get; set; }
        [Key]
        [Column("TagID")]
        public int TagId { get; set; }

        [ForeignKey(nameof(PhotoId))]
        [InverseProperty("Tags")]
        public virtual Photo Photo { get; set; }
    }
}
