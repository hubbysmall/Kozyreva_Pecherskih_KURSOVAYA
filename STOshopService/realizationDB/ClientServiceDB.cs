using STOshopModel;
using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace STOshopService.realizationDB
{
    public class ClientServiceDB : IClientService
    {
        private STOshopDBContext context;

        public ClientServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public List<ClientViewModel> GetList()
        {
            List<ClientViewModel> result = context.Clients
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientMail = rec.ClientFIO
                })
                .ToList();
            return result;
        }

        public ClientBindingModel GetElement(string login)
        {
            Client element = context.Clients.FirstOrDefault(rec => rec.ClientMail == login);
            if (element != null)
            {
                return new ClientBindingModel
                {
                    Id = element.Id,
                    ClientFIO = element.ClientFIO,
                    ClientMail = element.ClientMail,
                    ClientPassword = element.ClientPassword
                };
            }
            throw new Exception("Покупатель не найден");
        }

        public void AddElement(ClientBindingModel model)
        {
            Client element = context.Clients.FirstOrDefault(rec =>
                                    rec.ClientMail == model.ClientMail);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким логином");
            }
            context.Clients.Add(new Client
            {
                ClientFIO = model.ClientFIO,
                ClientMail = model.ClientMail,
                ClientPassword = model.ClientPassword
            });
            context.SaveChanges();
        }

        public void UpdElement(ClientBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void DelElement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
