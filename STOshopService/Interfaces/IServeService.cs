using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IServeService
    {
        List<ServeViewModel> GetList();

        ServeViewModel GetServe(int id);

        void AddServe(ServeBindingModel model);

        void UpdServe(ServeBindingModel model);

        void DelServe(int id);

    }
}
