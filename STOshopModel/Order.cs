using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Order
    {
        public int Id { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public DateTime DateCreate { get; set; }

        public virtual Part Part { get; set; }

    }
}
