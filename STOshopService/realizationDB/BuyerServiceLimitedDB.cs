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
    public class BuyerServiceLimitedDB : IBuyerServiceLimited
    {
        private STOshopDBContext context;
        private List<List<string>> clientsInfos;
        private List<List<Serve>> clientsServes;

        public BuyerServiceLimitedDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public List<BuyViewModel> GetList(ReportBindingModel model)
        {
            List<BuyViewModel> result = context.Buys.Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                .Select(rec => new BuyViewModel
                {
                    Id = rec.Id,
                    ClientFIO = context.Clients.FirstOrDefault(recClient => recClient.Id == rec.Id).ClientFIO,
                    TotalSum = rec.TotalSum,
                    DateCreate = rec.DateCreate,
                    Buy_Serves = context.Buy_Serves
                            .Where(recBS => recBS.BuyId == rec.Id)
                            .Select(recBS => new Buy_ServeViewModel
                            {
                                Id = recBS.Id,
                                BuyId = recBS.BuyId,
                                ServeId = recBS.ServeId,
                                ServeName = context.Serves.FirstOrDefault(recServe => recServe.Id == recBS.ServeId).ServeName,                               
                                Serve_Parts = context.Serve_Parts
                                    .Where(recSP => recSP.ServeId == recBS.ServeId)
                                    .Select(recSP => new Serve_PartViewModel
                                    {
                                        Id = recSP.Id,
                                        ServeId = recSP.ServeId,
                                        PartId = recSP.PartId,
                                        PartName = recSP.Part.PartName,
                                        Count = recSP.Count,
                                        PartPrice = recSP.Part.PartPrice
                                    })
                                    .ToList()
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public void generateRandomBuyerInfo() {

            clientsInfos = new List<List<string>>(3);
            for (int i = 0; i < 3; i++) {
                clientsInfos.Add(new List<string>());
            }
            clientsInfos[0] = new List<string>(new string[] { "Миша", "misha@mail.ru", "misha" });
            clientsInfos[1] = new List<string>(new string[] { "Маша", "masha@mail.ru", "masha" });
            clientsInfos[2] = new List<string>(new string[] { "Петр", "petr@mail.ru", "petr" });

            clientsServes = new List<List<Serve>>(3);
            for (int i = 0; i < 3; i++)
            {
                clientsServes.Add(new List<Serve>());
            }

            for (int i = 0; i < 3; i++) {
               // List<Serve> result = context.Serves.ToList();
                //RandomNotRepeat rand = new RandomNotRepeat(0, context.Serves.Count());
                //int serveId = rand.Next();
                Serve serveForBuy1 = context.Serves.FirstOrDefault(rec => rec.Id == 7);
               // serveId = rand.Next();
                Serve serveForBuy2 = context.Serves.FirstOrDefault(rec => rec.Id == 8);
                clientsServes[i].Add(serveForBuy1);
                clientsServes[i].Add(serveForBuy2);
            }

        }

        public void takeRandomBuyerInfo() {

            generateRandomBuyerInfo();

            using (var transaction = context.Database.BeginTransaction())
            {
               
                try
                {
                    for (int i = 0; i < 3; i++)
                    {

                        Client client = new Client
                        {
                            ClientFIO = clientsInfos[i][0],
                            ClientMail = clientsInfos[i][1],
                            ClientPassword = clientsInfos[i][2]
                        };
                        context.Clients.Add(client);
                        context.SaveChanges();

                        Buy buy = new Buy
                        {
                            //ClientId = context.Clients.Last<Client>().Id,
                            //ClientId = context.Clients.FirstOrDefault(rec => rec.ClientFIO == client.ClientFIO).Id,
                            ClientId = client.Id,
                            DateCreate = DateTime.Now,
                            TotalCount = 2
                        };
                        context.Buys.Add(buy);
                        context.SaveChanges();

                        int serveTotal = 0;
                        for (int j = 0; j < 2; j++)
                        {
                            Buy_Serve BS = new Buy_Serve
                            {
                                ServeId = clientsServes[i][j].Id,
                                BuyId = buy.Id
                            };
                            context.Buy_Serves.Add(BS);
                            context.SaveChanges();
                            Serve serveForBuy = context.Serves.FirstOrDefault(rec => rec.Id == BS.ServeId);
                            serveTotal = serveTotal + serveForBuy.MyPriceAndParts;
                        }
                        buy.TotalSum = serveTotal;
                        context.SaveChanges();
                    }

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
               
            }
             List<Buy> result = context.Buys.ToList();
            List<Buy_Serve> resul2t = context.Buy_Serves.ToList();
        }


    }
}
