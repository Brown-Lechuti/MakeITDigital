using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MakeITDigital.Models
{
    public partial class Metum
    {
        [Key]
        [Column("PhotoID")]
        public int PhotoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModStamp { get; set; }
        [StringLength(500)]
        public string Caption { get; set; }

        [ForeignKey(nameof(PhotoId))]
        [InverseProperty("Metum")]
        public virtual Photo Photo { get; set; }
    }
}
