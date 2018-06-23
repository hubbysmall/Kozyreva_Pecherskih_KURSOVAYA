using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.BindingModels
{
    public class Order_PartBindingModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int PartId { get; set; }

        public int HallId { get; set; }

        public string PartName { get; set; }

        public string HallName { get; set; }

        public int PartCount { get; set; }

        public int PartPrice { get; set; }
    }
}
