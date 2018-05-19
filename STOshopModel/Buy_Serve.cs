using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopModel
{
    public class Buy_Serve
    {
        public int Id { get; set; }

        public int ServeId { get; set; }

        public int BuyId { get; set; }

       // public int Count { get; set; } зачем в ТО дважды оказывать одну и ту же услугу за 1 раз

     //   public decimal Sum { get; set; } цена услуги укажется в Serve (работа + цена всех использованных Parts)

        public virtual Buy Buy { get; set; }

        public virtual Serve Serve { get; set; }
    }
}
