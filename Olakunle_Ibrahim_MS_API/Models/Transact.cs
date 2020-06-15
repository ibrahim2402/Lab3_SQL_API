using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olakunle_Ibrahim_MS_API.Models
{
    [Table("transact")]
    public partial class Transact
    {
        [Key]
        [Column("transactID")]
        public int TransactId { get; set; }
        [Column("id")]
        public int? Id { get; set; }
        [Column("transaction_date", TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Customer.Transact))]
        public virtual Customer IdNavigation { get; set; }
    }
}
