using STOshopModel;
using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.realizationDB
{
    public class MainClientServiceDB : IMainClientService
    {
        private STOshopDBContext context;

        public MainClientServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public void CreateBuy(BuyBindingModel model, List<ServeViewModel> listChoices)
        {
            Buy buy = new Buy
            {
                ClientId = model.ClientId,
                TotalSum = model.Sum,
                DateCreate = DateTime.Now
            };
            context.Buys.Add(buy);
            context.SaveChanges();
            List<Buy_Serve> buy_serves = new List<Buy_Serve>();
            for (int i = 0; i < listChoices.Count; i++)
            {
                Buy_Serve buy_serve = new Buy_Serve
                {
                    BuyId = buy.Id,
                    ServeId = listChoices[i].Id
                };
                context.Buy_Serves.Add(buy_serve);
                buy_serves.Add(buy_serve);
            }
            context.SaveChanges();
            //buy.Buy_Serves = buy_serves;
            context.SaveChanges();
        }

        public ClientViewModel getClient(int id)
        {
            Client element = context.Clients.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ClientViewModel
                {
                    Id = element.Id,
                    ClientFIO = element.ClientFIO,
                    ClientMail = element.ClientMail
                };
            }
            throw new Exception("Элемент не найден");
        }

        public ServeViewModel GetElement(int id)
        {
            Serve element = context.Serves.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ServeViewModel
                {
                    Id = element.Id,
                    ServeName = element.ServeName,
                    MyPriceAndParts = element.MyPriceAndParts
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<ServeViewModel> GetList()
        {
            List<ServeViewModel> result = new List<ServeViewModel>();
            foreach (var serve in context.Serves)
            {
                int count_parts = 0;//количество деталь-услуга
                int count = 0;      //есть ли деталь на складе
                foreach (var serve_parts in context.Serve_Parts)
                {
                    if (serve.Id == serve_parts.ServeId)
                    {
                        count_parts++;
                        foreach (var hall_parts in context.Hall_Parts)
                        {
                            if (serve_parts.PartId == hall_parts.PartId && serve_parts.Count <= hall_parts.Count)
                            {
                                count++;
                                break;
                            }
                        }
                    }
                }
                if (count == count_parts)
                {
                    result.Add(new ServeViewModel
                    {
                        Id = serve.Id,
                        ServeName = serve.ServeName,
                        MyPriceAndParts = serve.MyPriceAndParts
                    });
                }
            }
            return result;
        }
    }
}
