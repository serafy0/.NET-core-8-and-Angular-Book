﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCities.Server.Data.Models
{
    [Table("Cities")]
    [Index(nameof(Name))]
    [Index(nameof(Lat))]
    [Index(nameof(Lon))]
    public class City
    {
        #region Proberties

        [Key]
        [Required]
        public int Id { get; set; }
        public required string Name { get; set; }

        [Column(TypeName ="decimal(7,4)")]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        public decimal Lon { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        #endregion

        public Country? Country { get; set; }

    }
}
