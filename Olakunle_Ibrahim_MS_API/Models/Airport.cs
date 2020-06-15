using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("airport")]
    public partial class Airport
    {
        public Airport()
        {
            Route = new HashSet<Route>();
        }

        [Key]
        [Column("airport_code")]
        [StringLength(3)]
        public string AirportCode { get; set; }
        [Column("airport_city")]
        [StringLength(30)]
        public string AirportCity { get; set; }
        [Column("latiitude")]
        [StringLength(30)]
        public string Latiitude { get; set; }
        [Column("longitutude")]
        [StringLength(10)]
        public string Longitutude { get; set; }

        [InverseProperty("AirportCodeNavigation")]
        public virtual ICollection<Route> Route { get; set; }
    }
}
