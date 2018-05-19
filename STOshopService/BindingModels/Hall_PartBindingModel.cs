using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.BindingModels
{
    public class Hall_PartBindingModel
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        public int PartId { get; set; }

        public int Count { get; set; }
    }
}
