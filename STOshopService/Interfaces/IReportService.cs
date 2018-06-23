using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IReportService
    {

        List<AdminOrdersViewModel> GetAdminOrders(ReportBindingModel model);

        void SaveAdminOrders(ReportBindingModel model);

        List<BuyerBuysViewModel> GetBuyerBuys(ReportBindingModel model);

       void SaveBuyerBuys(ReportBindingModel model);

        List<Serve_PartViewModel> GetPartsListBySerVeId(int serveID);
    }
}
