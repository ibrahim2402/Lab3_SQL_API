using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("car_rental")]
    public partial class CarRental
    {
        [Key]
        [Column("company_code")]
        [StringLength(3)]
        public string CompanyCode { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("company_name")]
        [StringLength(30)]
        public string CompanyName { get; set; }
        [Column("licence_no")]
        [StringLength(30)]
        public string LicenceNo { get; set; }
        [Column("car_no")]
        [StringLength(10)]
        public string CarNo { get; set; }
        [Column("rental_date", TypeName = "datetime")]
        public DateTime RentalDate { get; set; }
        [Required]
        [Column("price")]
        [StringLength(10)]
        public string Price { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Customer.CarRental))]
        public virtual Customer IdNavigation { get; set; }
    }
}
