using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IPartService
    {
        List<PartViewModel> GetList();

        PartViewModel GetPart(int id);

        void AddPart(PartBindingModel model);

        void UpdPart(PartBindingModel model);

        void DelPart(int id);

        int GetPartPrice(int id);
    }
}
