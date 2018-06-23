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
    public class HallServiceDB : IHallService
    {
        private STOshopDBContext context;

        public HallServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public List<HallViewModel> GetList()
        {
            List<HallViewModel> result = context.Halls
                .Select(rec => new HallViewModel
                {
                    Id = rec.Id,
                    HallName = rec.HallName,
                    Hall_Parts = context.Hall_Parts
                            .Where(recPC => recPC.HallId == rec.Id)
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
        }

        public HallViewModel GetHall(int id)
        {
            Hall element = context.Halls.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new HallViewModel
                {
                    Id = element.Id,
                    HallName = element.HallName,
                    Hall_Parts = context.Hall_Parts
                            .Where(recPC => recPC.HallId == element.Id)
                            .Select(recPC => new Hall__PartViewModel
                            {
                                Id = recPC.Id,
                                HallId = recPC.HallId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                PartCount = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddHall(HallBindingModel model)
        {
            Hall element = context.Halls.FirstOrDefault(rec => rec.HallName == model.HallName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            context.Halls.Add(new Hall
            {
                HallName = model.HallName
            });
            context.SaveChanges();
            //ТЕПЕРЬ НУЖНО В ЭТОТ НОВЫЙ СКЛАД ДОБАВИТЬ НОМИНАЛЫ ВСЕХ ДЕТАЛЕЙ С КОЛ-ВОМ == 0
            int hallid = 0;
            foreach (Hall nominal in context.Halls)
            {
                 hallid = nominal.Id;
             
            }
            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
           // int hallId = context.Halls.Last(rec => rec.HallName == model.HallName).Id;
            foreach(Part nominal in context.Parts)
            {
                context.Hall_Parts.Add(new Hall_Part
                {
                    HallId = hallid,
                    PartId = nominal.Id,
                    Count = 0
                });
            }
            context.SaveChanges();
        }

        public void UpdHall(HallBindingModel model)
        {
            Hall element = context.Halls.FirstOrDefault(rec =>
                                        rec.HallName == model.HallName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Halls.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.HallName = model.HallName;
            context.SaveChanges();
        }

        public void DelHall(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Hall element = context.Halls.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // при удалении удаляем все записи о компонентах на удаляемом складе
                        context.Hall_Parts.RemoveRange(
                                            context.Hall_Parts.Where(rec => rec.HallId == id));
                        context.Halls.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
