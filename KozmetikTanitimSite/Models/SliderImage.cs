using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KozmetikTanitimSite.Models
{
    public class SliderImage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Resim URL'si zorunludur.")]
        public string ImageUrl { get; set; }

        // İsteğe bağlı: ürünle ilişkilendirme
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
