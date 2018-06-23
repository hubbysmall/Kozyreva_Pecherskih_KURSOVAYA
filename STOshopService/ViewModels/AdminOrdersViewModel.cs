using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class AdminOrdersViewModel  //???????????????????????????????
    {
        public string AdminName { get; set; }

        public int TotalCount { get; set; }

        public int TotalSum { get; set; }

        public DateTime DateCreate { get; set; }

        public IEnumerable<Tuple<string, string, int, int>> Parts { get; set; }  //PartsName-hallNAme-quantity-price
    }
}
