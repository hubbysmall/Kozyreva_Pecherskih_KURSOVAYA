using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IHallService
    {
        List<HallViewModel> GetList();

        HallViewModel GetHall(int id);

        void AddHall(HallBindingModel model);

        void UpdHall(HallBindingModel model);

        void DelHall(int id);
    }
}
