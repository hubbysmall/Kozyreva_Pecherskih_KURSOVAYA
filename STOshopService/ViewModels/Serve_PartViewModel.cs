using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class Serve_PartViewModel
    {
        public int Id { get; set; }

        public int ServeId { get; set; }

        public int PartId { get; set; }

        public string PartName { get; set; }

        public int Count { get; set; }

        public int PartPrice { get; set; }
    }
}
