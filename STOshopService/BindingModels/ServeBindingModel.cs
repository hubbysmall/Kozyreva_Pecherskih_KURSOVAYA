using System.Collections.Generic;

namespace STOshopService.BindingModels
{

    public class ServeBindingModel
    {

        public int Id { get; set; }

        public string ServeName { get; set; }

        public int MyPrice { get; set; } // это стоимость работы

        public int MyPriceAndParts { get; set; } // будет высчитываться с учетом задействованных запчастей и ценой самой услуги автоматическм
        // MyPriceAndParts -- это и есть финальная цена услуги
        public List<Serve_PartBindingModel> Serve_Parts { get; set; }
    }
}
