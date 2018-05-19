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

        public List<OrderViewModel> GetList_OrderReport(DateTime from, DateTime to)
        {
            /*
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
            */
            return null;
        }

        public List<HallViewModel> ShowExhaustingParts() {
            /*
            List<HallViewModel> result = context.Halls
                .Select(rec => new HallViewModel
                {
                    Id = rec.Id,
                    HallName = rec.HallName,
                    Hall_Parts = context.Hall_Parts
                            .Where(recPC => recPC.HallId == rec.Id && recPC.Count < 10)
                            .Select(recPC => new Hall__PartViewModel
                            {
                                Id = recPC.Id,
                                HallId = recPC.HallId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                PartCount = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
            */
            return null;
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
        }
    }
}
