using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("airline")]
    public partial class Airline
    {
        public Airline()
        {
            Route = new HashSet<Route>();
        }

        [Key]
        [Column("airline_code")]
        [StringLength(2)]
        public string AirlineCode { get; set; }
        [Column("airline_name")]
        [StringLength(30)]
        public string AirlineName { get; set; }
        [Required]
        [Column("departure")]
        [StringLength(30)]
        public string Departure { get; set; }
        [Required]
        [Column("arrival")]
        [StringLength(30)]
        public string Arrival { get; set; }

        [InverseProperty("AirlineCodeNavigation")]
        public virtual ICollection<Route> Route { get; set; }
    }
}
