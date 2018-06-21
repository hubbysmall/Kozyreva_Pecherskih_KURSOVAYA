using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IMainClientService
    {
        List<ServeViewModel> GetList();

        ServeViewModel GetElement(int id);

        ClientViewModel getClient(int id);

        void CreateBuy(BuyBindingModel model, List<ServeViewModel> listChoices);

    }
}
