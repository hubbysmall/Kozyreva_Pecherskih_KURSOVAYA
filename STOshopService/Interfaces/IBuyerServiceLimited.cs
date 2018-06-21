using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IBuyerServiceLimited
    {
        void generateRandomBuyerInfo();
        void takeRandomBuyerInfo();
        List<BuyViewModel> GetList(ReportBindingModel model);
    }
}
