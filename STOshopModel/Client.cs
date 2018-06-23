using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace STOshopModel
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string ClientFIO { get; set; }

        [ForeignKey("ClientId")]
        public virtual List<Buy> Buys { get; set; }
        [DataMember]
        [Required]
        public string ClientMail { get; set; }
        [DataMember]
        [Required]
        public string ClientPassword { get; set; }
    }
}
