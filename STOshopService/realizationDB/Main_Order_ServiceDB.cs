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
    public class Main_Order_ServiceDB : IMain_Order_Service
    {
        private STOshopDBContext context;

        public Main_Order_ServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public void PutOrderedPartsInHall(List<Hall_PartBindingModel> newParts) {

            foreach(Hall_PartBindingModel h_P in newParts)
            {
                Hall_Part element = context.Hall_Parts
                                              .FirstOrDefault(rec => rec.HallId == h_P.HallId &&
                                                                  rec.PartId == h_P.PartId);
                element.Count += h_P.Count;
            }
            context.SaveChanges();
        }

        public Hall__PartViewModel GetHall_Part(int id)
        {
            Hall_Part element = context.Hall_Parts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new Hall__PartViewModel
                {
                    Id = element.Id,
                    HallId= element.HallId,
                    PartId = element.PartId,
                   // PartName = element.Part.PartName,
                   // HallName = element.Hall.HallName,
                    PartCount = element.Count
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> GetList_OrderReport(DateTime from, DateTime to)
        {
            
            List<OrderViewModel> result = context.Orders
                .Where(rec => rec.DateCreate >= from && rec.DateCreate <= to).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    AdminName = rec.AdminName,
                    TotalSum = rec.TotalSum,
                    Order_Parts = context.Order_Parts
                            .Where(recPC => recPC.OrderId == rec.Id)
                            .Select(recPC => new Order_PartViewModel
                            {
                                Id = recPC.Id,
                                OrderId = recPC.OrderId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                PartCount = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
           
        }

        public List<Hall__PartViewModel> ShowExhaustingParts() {
           
            List<Hall__PartViewModel> result = context.Hall_Parts
                .Where(recPC => recPC.Count == 0)
                .Select(recPC => new Hall__PartViewModel
                {
                    Id = recPC.Id,
                    HallId = recPC.HallId,
                    PartId = recPC.PartId,
                    PartName = recPC.Part.PartName,
                    PartCount = recPC.Count,
                    HallName = recPC.Hall.HallName
                })
                .ToList();
            return result;

        }

        public void refillPartsRow(int id) {
            /*
            Hall_Part element = context.Hall_Parts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PartViewModel
                {
                    Id = element.Id,
                    PartName = element.PartName,
                    PartPrice = element.PartPrice
                };
            }
            throw new Exception("Элемент не найден");
            */
        }

        public void CreateOrder_AND_PutOrderedPartsInHall(OrderBindingModel model) {
            /*
              context.Orders.Add(new Order
              {
                  AdminId = model.AdminId,
                  AdminName = model.AdminName,
                  TotalCount = model.TotalCount,
                  TotalSum = model.TotalSum,
                  DateCreate = DateTime.Now,
                  Order_Parts = model.Order_Parts

              });
              foreach(Order_PartBindingModel order_part in model.Order_Parts)
              {

                  Hall_Part elementPC = context.Hall_Parts
                                          .FirstOrDefault(rec => rec.HallId == order_part.HallId);
                  if (elementPC != null)
                  {
                      elementPC.Count += order_part.Count;
                      context.SaveChanges();
                  }
              }
              context.SaveChanges();
              */
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Orders.Add(new Order
                    {
                        AdminId = model.AdminId,
                        AdminName = model.AdminName,
                        TotalCount = model.TotalCount,
                        TotalSum = model.TotalSum,
                        DateCreate = DateTime.Now
                    });
                    context.SaveChanges();
                    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    //int elementId = context.Orders.LastOrDefault().Id;
                    int ourOrderid = 0;
                    foreach (Order ourOrder in context.Orders)
                    {
                        ourOrderid = ourOrder.Id;

                    }


                    // убираем дубли по компонентам
                    var groupComponents = model.Order_Parts;
                      
                    



                    // добавляем компоненты
                    foreach (var groupComponent in groupComponents)
                    {
                        context.Order_Parts.Add(new Order_Part
                        {                          
                            OrderId = ourOrderid,
                            PartId = groupComponent.PartId,
                            HallId = groupComponent.HallId,
                            Count = groupComponent.PartCount

                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                //НЕ ЗАБЫТЬ ПОПОЛНИТЬ СКЛАДЫ!!!
            }
        }
    }
}
