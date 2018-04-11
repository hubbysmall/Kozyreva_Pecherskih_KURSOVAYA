using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Buy
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ServeId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public BuyStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateExecute { get; set; }

        public virtual Client Client { get; set; }

        public virtual Serve Serve { get; set; }

    }
}
