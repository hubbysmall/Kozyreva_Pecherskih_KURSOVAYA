using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class ClientBuysModel
    {
        public string ClientName { get; set; }

        public DateTime DateCreate { get; set; }

        public IEnumerable<Tuple<string, List<Serve_PartViewModel>, int>> Serve_Parts { get; set; }

        public int TotalCount { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }
    }
}
