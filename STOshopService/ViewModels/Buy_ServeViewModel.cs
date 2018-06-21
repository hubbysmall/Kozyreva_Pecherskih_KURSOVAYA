using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class Buy_ServeViewModel
    {
        public int Id { get; set; }

        public int BuyId { get; set; }

        public int ServeId { get; set; }

        public string ServeName { get; set; }

        public List<Serve_PartViewModel> Serve_Parts { get; set; }

        // public int Count { get; set; }
    }
}
