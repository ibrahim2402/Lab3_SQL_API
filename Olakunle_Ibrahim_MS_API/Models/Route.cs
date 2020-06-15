using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("route")]
    public partial class Route
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("flight_no")]
        public int? FlightNo { get; set; }
        [Required]
        [Column("airline_code")]
        [StringLength(2)]
        public string AirlineCode { get; set; }
        [Required]
        [Column("airport_code")]
        [StringLength(3)]
        public string AirportCode { get; set; }

        [ForeignKey(nameof(AirlineCode))]
        [InverseProperty(nameof(Airline.Route))]
        public virtual Airline AirlineCodeNavigation { get; set; }
        [ForeignKey(nameof(AirportCode))]
        [InverseProperty(nameof(Airport.Route))]
        public virtual Airport AirportCodeNavigation { get; set; }
        [ForeignKey(nameof(FlightNo))]
        [InverseProperty(nameof(Flight.Route))]
        public virtual Flight FlightNoNavigation { get; set; }
    }
}
