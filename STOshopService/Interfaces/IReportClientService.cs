using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IReportClientService
    {
        void SaveServePriceDoc(ReportClientBindingModel model);

        void SaveServePriceExcel(ReportClientBindingModel model);

        void SaveClientBuy(ReportClientBindingModel model, int idClient);

        List<ClientBuysModel> GetClientBuys(ReportClientBindingModel model, int idClient);

        List<Serve_PartViewModel> GetPartsListByServeId(int ServeId);
    }
}
