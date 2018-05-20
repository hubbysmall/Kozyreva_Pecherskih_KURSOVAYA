using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.BindingModels
{
    public class OrderBindingModel
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public string AdminName { get; set; }

        //public int PartId { get; set; }

        public int TotalCount { get; set; }

        public decimal TotalSum { get; set; }

        public List<Order_PartBindingModel> Order_Parts { get; set; }
    }
}
