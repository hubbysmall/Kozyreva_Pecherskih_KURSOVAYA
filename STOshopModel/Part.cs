using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        public string PartName { get; set; }

        [Required]
        public int PartPrice { get; set; }

        [ForeignKey("PartId")]
        public virtual List<Serve_Part> Serve_Parts { get; set; }

        [ForeignKey("PartId")]
        public virtual List<Order_Part> Orders { get; set; }

        [ForeignKey("PartId")]
        public virtual List<Hall_Part> Halls { get; set; }

    
    }
}
