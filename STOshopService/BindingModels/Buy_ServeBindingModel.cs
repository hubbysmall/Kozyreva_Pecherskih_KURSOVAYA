using System.Runtime.Serialization;

namespace STOshopService.BindingModels
{
    public class Buy_ServeBindingModel
    {
        public int Id { get; set; }

        public int BuyId { get; set; }

        public int ServeId { get; set; }
    }
}
