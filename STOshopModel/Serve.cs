using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Serve
    {
        public int Id { get; set; }

        [Required]
        public string ServeName { get; set; }

        [Required]
        public int ServePrice { get; set; }

        public int MyPriceAndParts { get; set; }// общая (работа+запчасти)

        [ForeignKey("ServeId")]
        public virtual List<Serve_Part> Serve_Parts { get; set; }
    }
}
