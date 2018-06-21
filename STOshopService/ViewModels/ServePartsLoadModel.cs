using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class ServePartsLoadModel
    {
        public string ServeName { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<Tuple<string, List<Serve_PartViewModel>, int>> Parts { get; set; }
    }
}
