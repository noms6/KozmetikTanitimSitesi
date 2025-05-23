using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KozmetikTanitimSite.Models
{
    public class Return
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public string Status { get; set; } // "Pending", "Approved", "Rejected"

        [Required]
        public DateTime RequestDate { get; set; }
    }
}