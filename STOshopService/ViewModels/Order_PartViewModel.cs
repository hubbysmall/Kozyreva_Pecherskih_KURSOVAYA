using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class Order_PartViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int HallId { get; set; }

        public int PartId { get; set; }

        public string PartName { get; set; }

        public int PartCount { get; set; }
    }
}
