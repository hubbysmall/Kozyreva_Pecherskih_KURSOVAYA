using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class BuyerBuysViewModel   //???????????????????????????????
    {
        public string BuyerName { get; set; }

        public DateTime DateCreate { get; set; }

        //public List<Buy_ServeViewModel> Buy_Serves { get; set; }

        public IEnumerable<Tuple<string, List<Serve_PartViewModel>, int>> ServesInParts { get; set; }  //ServeName-LIstOfParts-ServeWholePrice

        public int TotalCount { get; set; }

        public int TotalSum { get; set; }

    }
}
