using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Hall_Part
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }

        public virtual Hall Hall { get; set; }

        public virtual Part Part { get; set; }
    }
}
