using STOshopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public string AdminName { get; set; }

        public List<Order_PartViewModel> Order_Parts { get; set; }

        public decimal TotalSum { get; set; }

        public string DateCreate { get; set; }

    }
}
