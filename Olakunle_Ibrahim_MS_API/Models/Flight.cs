using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("flight")]
    public partial class Flight
    {
        public Flight()
        {
            Route = new HashSet<Route>();
        }

        [Key]
        [Column("flight_no")]
        public int FlightNo { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("departure_date", TypeName = "datetime")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [Column("ticket_price")]
        [StringLength(10)]
        public string TicketPrice { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Customer.Flight))]
        public virtual Customer IdNavigation { get; set; }
        [InverseProperty("FlightNoNavigation")]
        public virtual ICollection<Route> Route { get; set; }
    }
}
