using STOshopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.ViewModels
{
    public class BuyViewModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string ClientFIO { get; set; }

        public List<Buy_ServeViewModel> Buy_Serves { get; set; }

        public int TotalSum { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
