using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Hall
    {
        public int Id { get; set; }

        [Required]
        public string HallName { get; set; }

        [ForeignKey("HallId")]
        public virtual List<Hall_Part> Hall_Parts { get; set; }
    }
    
}
