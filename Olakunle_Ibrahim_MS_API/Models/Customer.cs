using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("customer")]
    public partial class Customer
    {
        public Customer()
        {
            CarRental = new HashSet<CarRental>();
            Flight = new HashSet<Flight>();
            Transact = new HashSet<Transact>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("card_no")]
        [StringLength(16)]
        public string CardNo { get; set; }
        [Required]
        [Column("passenger_name")]
        [StringLength(30)]
        public string PassengerName { get; set; }
        [Column("expire_date")]
        [StringLength(10)]
        public string ExpireDate { get; set; }
        [Column("balance")]
        [StringLength(10)]
        public string Balance { get; set; }
        [Column("passport_no")]
        [StringLength(10)]
        public string PassportNo { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual ICollection<CarRental> CarRental { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual ICollection<Flight> Flight { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual ICollection<Transact> Transact { get; set; }
    }
}
