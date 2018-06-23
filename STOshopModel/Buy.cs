using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    [DataContract]
    public class Buy
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public int TotalSum { get; set; }
        [DataMember]
        public DateTime DateCreate { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey("BuyId")]
        public virtual List<Buy_Serve> Buy_Serves { get; set; }

    }
}
