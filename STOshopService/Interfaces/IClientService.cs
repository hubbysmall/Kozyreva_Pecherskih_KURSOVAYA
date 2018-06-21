using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IClientService
    {
        List<ClientViewModel> GetList();

        //ClientViewModel GetElement(int id);

        ClientBindingModel GetElement(string id);

        void AddElement(ClientBindingModel model);

        void UpdElement(ClientBindingModel model);

        void DelElement(int id);
    }
}
