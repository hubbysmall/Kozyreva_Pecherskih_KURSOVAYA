using STOshopModel;
using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace STOshopService.realizationDB
{
    public class ServeServiceDB : IServeService
    {
        private STOshopDBContext context;

        public ServeServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public List<ServeViewModel> GetList()
        {         
            List<ServeViewModel> result = context.Serves
                .Select(rec => new ServeViewModel
                {
                    Id = rec.Id,
                    ServeName = rec.ServeName,
                    Price = rec.ServePrice,
                    MyPriceAndParts = rec.MyPriceAndParts,
                    Serve_Parts = context.Serve_Parts
                            .Where(recPC => recPC.ServeId == rec.Id)
                            .Select(recPC => new Serve_PartViewModel
                            {
                                Id = recPC.Id,
                                ServeId = recPC.ServeId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,   
                                Count = recPC.Count,
                                PartPrice = recPC.Part.PartPrice
                            })
                            .ToList()
                })
                .ToList();
            return result;        
        }

        public ServeViewModel GetServe(int id)
        {
            Serve element = context.Serves.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ServeViewModel
                {
                    Id = element.Id,
                    ServeName = element.ServeName,
                    Price = element.ServePrice,
                    MyPriceAndParts = element.MyPriceAndParts,
                    Serve_Parts = context.Serve_Parts
                            .Where(recPC => recPC.ServeId == element.Id)
                            .Select(recPC => new Serve_PartViewModel
                            {
                                Id = recPC.Id,
                                ServeId = recPC.ServeId,
                                PartId = recPC.PartId,
                                PartName = recPC.Part.PartName,
                                Count = recPC.Count,
                                PartPrice = recPC.Part.PartPrice
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");                    
        }

        public void AddServe(ServeBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Serve element = context.Serves.FirstOrDefault(rec => rec.ServeName == model.ServeName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Serve
                    {
                        ServeName = model.ServeName,
                        ServePrice = model.MyPrice,
                        MyPriceAndParts = model.MyPriceAndParts
                    };
                    context.Serves.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupComponents = model.Serve_Parts
                                                .GroupBy(rec => rec.PartId)
                                                .Select(rec => new
                                                {
                                                    PartId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)                                                  
                                                });
                    // добавляем компоненты
                    foreach (var groupComponent in groupComponents)
                    {
                        context.Serve_Parts.Add(new Serve_Part
                        {
                            ServeId = element.Id,
                            PartId = groupComponent.PartId,
                            Count = groupComponent.Count
           
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
            }
        }

        public void UpdServe(ServeBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Serve element = context.Serves.FirstOrDefault(rec =>
                                        rec.ServeName == model.ServeName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Serves.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.ServeName = model.ServeName;
                    element.ServePrice = model.MyPrice;
                    element.MyPriceAndParts = model.MyPriceAndParts;
                    context.SaveChanges();

                    // обновляем существуюущие компоненты
                    var compIds = model.Serve_Parts.Select(rec => rec.PartId).Distinct();
                    var updateComponents = context.Serve_Parts
                                                    .Where(rec => rec.ServeId == model.Id &&
                                                        compIds.Contains(rec.PartId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.Count = model.Serve_Parts
                                                        .FirstOrDefault(rec => rec.Id == updateComponent.Id).Count;
                    }
                    context.SaveChanges();
                    context.Serve_Parts.RemoveRange(
                                        context.Serve_Parts.Where(rec => rec.ServeId == model.Id &&
                                                                            !compIds.Contains(rec.ServeId)));
                    context.SaveChanges();
                    // новые записи
                    var groupComponents = model.Serve_Parts
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.PartId)
                                                .Select(rec => new
                                                {
                                                    PartId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        Serve_Part elementPC = context.Serve_Parts
                                                .FirstOrDefault(rec => rec.ServeId == model.Id &&
                                                                rec.PartId == groupComponent.PartId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Serve_Parts.Add(new Serve_Part
                            {
                                ServeId = model.Id,
                                PartId = groupComponent.PartId,
                                Count = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
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

        public void DelServe(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Serve element = context.Serves.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.Serve_Parts.RemoveRange(
                                            context.Serve_Parts.Where(rec => rec.ServeId == id));
                        context.Serves.Remove(element);
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
