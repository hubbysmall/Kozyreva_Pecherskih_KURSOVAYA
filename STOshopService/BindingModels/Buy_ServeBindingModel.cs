using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.BindingModels
{
    public class Buy_ServeBindingModel
    {
        public int Id { get; set; }

        public int BuyId { get; set; }

        public int ServeId { get; set; }

        //public int Count { get; set; } одна услуга за раз по умолч.
    }
}
