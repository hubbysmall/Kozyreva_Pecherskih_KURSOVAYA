using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.BindingModels
{
    public class Serve_PartBindingModel
    {
        public int Id { get; set; }

        public int ServeId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; } // в рамках 1 услуги может применяться более одной одинаковой запчасти
    }
}
