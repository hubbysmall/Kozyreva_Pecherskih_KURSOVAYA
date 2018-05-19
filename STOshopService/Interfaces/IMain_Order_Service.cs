﻿using STOshopService.BindingModels;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.Interfaces
{
    public interface IMain_Order_Service
    {
        List<OrderViewModel> GetList_OrderReport(DateTime from, DateTime to);

        List<HallViewModel> ShowExhaustingParts();

        void CreateOrder_AND_PutOrderedPartsInHall(OrderBindingModel model); // все запчасти чьё количество подходит к концу
        // выполняется сразу после  CreateOrder с учетом указанного в CreateOrder
        // количества всех заказанных запчастей 
     
    }
}
