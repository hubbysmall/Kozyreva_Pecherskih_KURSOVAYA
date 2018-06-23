using System.Runtime.Serialization;

namespace STOshopModel
{
    [DataContract]
    public class Buy_Serve
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ServeId { get; set; }
        [DataMember]
        public int BuyId { get; set; }

        public virtual Buy Buy { get; set; }

        public virtual Serve Serve { get; set; }
    }
}
