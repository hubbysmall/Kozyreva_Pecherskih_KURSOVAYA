using STOshopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class ServeViewModel
    {
        public int Id { get; set; }

        public string ServeName { get; set; }

        public int Price { get; set; } 

        public int MyPriceAndParts { get; set; }// общая (работа+запчасти)

        public List<Serve_PartViewModel> Serve_Parts { get; set; }
    }
}
