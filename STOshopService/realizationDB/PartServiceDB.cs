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
    public class PartServiceDB : IPartService
    {
        private STOshopDBContext context;

        public PartServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }
        public List<PartViewModel> GetList()
        {
            List<PartViewModel> result = context.Parts
                .Select(rec => new PartViewModel
                {
                    Id = rec.Id,
                    PartName = rec.PartName,
                    PartPrice = rec.PartPrice
                })
                .ToList();
            return result;
        }

        public int GetPartPrice(int id)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                int PartPrice = element.PartPrice;
                return PartPrice;
               
            }
            throw new Exception("Элемент не найден");
        }

        public PartViewModel GetPart(int id)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.Id == id);
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
        }

        public void AddPart(PartBindingModel model)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.PartName == model.PartName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            context.Parts.Add(new Part
            {
                PartName = model.PartName,
                PartPrice = model.PartPrice
            });
            context.SaveChanges();

        }

        public void UpdPart(PartBindingModel model)
        {
            Part element = context.Parts.FirstOrDefault(rec =>
                                        rec.PartName == model.PartName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = context.Parts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.PartName = model.PartName;
            element.PartPrice = model.PartPrice;
            context.SaveChanges();
        }
        public void DelPart(int id)
        {
            Part element = context.Parts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Parts.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
