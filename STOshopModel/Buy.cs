using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Buy
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

       // public int ServeId { get; set; }

        public int? ExecutorId { get; set; }

        public int TotalCount { get; set; }

        public decimal TotalSum { get; set; }

        public BuyStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateExecute { get; set; }

        public virtual Client Client { get; set; }

        // public virtual Serve Serve { get; set; }

        [ForeignKey("BuyId")]
        public virtual List<Buy_Serve> Buy_Serves { get; set; }

        public virtual Executor Executor { get; set; }
    }
}
