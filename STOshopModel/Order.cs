using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Order
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public string AdminName { get; set; }

        public int TotalCount { get; set; }

        public int TotalSum { get; set; }

        public DateTime DateCreate { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<Order_Part> Order_Parts { get; set; }

    }
}
