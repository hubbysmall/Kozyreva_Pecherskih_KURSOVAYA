using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Serve_Part
    {
        public int Id { get; set; }

        public int ServeId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }

        public virtual Serve Serve { get; set; }

        public virtual Part Part { get; set; }
    }
}
