using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    class Admin
    {
        public int Id { get; set; }

        [Required]
        public string AdminMail { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Required]
        public string AdminPassword { get; set; }

        [ForeignKey("AdminId")]
        public virtual List<Order> Orders { get; set; }
    }
}
