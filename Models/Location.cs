using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MakeITDigital.Models
{
    [Table("Location")]
    public partial class Location
    {
        [Key]
        [Column("PhotoID")]
        public int PhotoId { get; set; }
        [StringLength(100)]
        public string ProvinceOrState { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Longitude { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Latitude { get; set; }

        [ForeignKey(nameof(PhotoId))]
        [InverseProperty("Location")]
        public virtual Photo Photo { get; set; }
    }
}
