using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string ClientFIO { get; set; }


        [ForeignKey("ClientId")]
        public virtual List<Buy> Buys { get; set; }

        [Required]
        public string ClientMail { get; set; }

        [Required]
        public string ClientPassword { get; set; }

        [Required]
        public bool ClientAccess { get; set; }

    }
}
