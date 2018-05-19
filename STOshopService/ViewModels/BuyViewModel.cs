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

        //public int ServeId { get; set; }

        public List<Buy_Serve> Buy_Serves { get; set; }

        // public string ServeName { get; set; } не одну же услугу можно купить а несколько

        public int? ExecutorId { get; set; }

        public string ExecutorName { get; set; }

     //   public int Count { get; set; }

        public decimal TotalSum { get; set; }

        public string Status { get; set; }

        public string DateCreate { get; set; }

        public string DateExecute { get; set; }
    }
}
