using STOshopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class HallViewModel
    {
        public int Id { get; set; }

        public string HallName { get; set; }

        public List<Hall__PartViewModel> Hall_Parts { get; set; }
    }
}
