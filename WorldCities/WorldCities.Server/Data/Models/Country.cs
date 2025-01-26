using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCities.Server.Data.Models
{
    [Index(nameof(Name))]
    [Index(nameof(ISO2))]
    [Index(nameof(ISO3))]
    [Table("Countries")]
    public class Country
    {
        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string ISO2 { get; set; }

        public required string ISO3 { get; set; }

        #endregion

        #region Navigation Properties
        public ICollection<City>? Cities { get; set; }
        #endregion


    }
}
