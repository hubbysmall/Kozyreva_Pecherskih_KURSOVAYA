using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using STOshopService.BindingModels;
using System.Data.Entity.SqlServer;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace STOshopService.realizationDB
{
    public class ReportServiceDB : IReportService
    {
        private STOshopDBContext context;

        public ReportServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public List<AdminOrdersViewModel> GetAdminOrders(ReportBindingModel model)
        {
            return context.Orders
                            .ToList().Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                            .GroupJoin(
                                    context.Order_Parts
                                                .Include(r => r.Part)
                                                .ToList(),
                                    order => order,
                                    orderPart => orderPart.Order,
                                    (order, orderPartList) =>
            new AdminOrdersViewModel
            {
                AdminName = order.AdminName,
                TotalCount = orderPartList.Sum(r => r.Count),
                TotalSum = order.TotalSum,
                DateCreate =  order.DateCreate,
                Parts = orderPartList.Select(r => new Tuple<string,string,int,int>(r.Part.PartName, context.Halls.FirstOrDefault(rec => rec.Id == r.HallId).HallName, r.Count, r.Part.PartPrice))
                
        
           
          
            })
                            .ToList();
        }

        public List<BuyerBuysViewModel> GetBuyerBuys(ReportBindingModel model)
        {
            return context.Buys
                            .ToList().Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo )
                            .GroupJoin(
                                    context.Buy_Serves
                                                .Include(r => r.Serve)
                                                .ToList(),
                                    buy => buy,
                                    buyServe => buyServe.Buy,
                                    (buy, buyServeList) =>
            new BuyerBuysViewModel
            {
                BuyerName = context.Clients.FirstOrDefault(rec => rec.Id == buy.ClientId).ClientFIO,
                TotalCount = buy.TotalCount,
                TotalSum = buy.TotalSum,
                DateCreate = buy.DateCreate,
                ServesInParts = buyServeList.Select(r => new Tuple<string, List<Serve_PartViewModel>,
                int>(r.Serve.ServeName, GetPartsListBySerVeId(r.ServeId), r.Serve.MyPriceAndParts))
            })
                            .ToList();
        }

        public List<Serve_PartViewModel> GetPartsListBySerVeId(int serveID)
        {
            List<Serve_PartViewModel> result = context.Serve_Parts
                    .Where(recPC => recPC.ServeId == serveID)
                    .Select(recPC => new Serve_PartViewModel
                    {
                        Id = recPC.Id,
                        ServeId = recPC.ServeId,
                        PartId = recPC.PartId,
                        PartName = recPC.Part.PartName,
                        Count = recPC.Count,
                        PartPrice = recPC.Part.PartPrice
                    })
                    .ToList();
               
            return result;
        }



        public void SaveAdminOrders(ReportBindingModel model)
        {
            //из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }
            //открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //вставляем заголовок
            var phraseTitle = new Phrase("Заявки поставщикам",
                new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            var phrasePeriod = new Phrase("c " + model.DateFrom.Value.ToShortDateString() +
                                    " по " + model.DateTo.Value.ToShortDateString(),
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phrasePeriod)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(4)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160, 100});
            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
            
            table.AddCell(new PdfPCell(new Phrase("Заказанные запчасти", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Для склада", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Количество", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Стоимость", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
          
            //заполняем таблицу
            var list = GetAdminOrders(model);
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.Count; i++)
            {
               
                cell = new PdfPCell(new Phrase(list[i].DateCreate.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Colspan = 6,
                    Border = 0
                };
                table.AddCell(cell);
                foreach (var part in list[i].Parts) {
                    cell = new PdfPCell(new Phrase(part.Item1, fontForCells));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(part.Item2, fontForCells));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(part.Item3.ToString(), fontForCells));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(part.Item4.ToString(), fontForCells));
                    table.AddCell(cell);
                }
                cell = new PdfPCell(new Phrase("Запчастей всего:", fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Colspan = 2,
                    Border = 0
                };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].TotalCount.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Colspan = 2,
                    Border = 0
                };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Итого:", fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Colspan = 3,
                    Border = 0
                };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].TotalSum.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Colspan = 1,
                    Border = 0
                };
                table.AddCell(cell);
            }
            //вставляем таблицу
            doc.Add(table);

            doc.Close();
        }

        public void SaveBuyerBuys(ReportBindingModel model)
        {
            //из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }
            //открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //вставляем заголовок
            var phraseTitle = new Phrase("Заказы клиентов",
                new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            var phrasePeriod = new Phrase("c " + model.DateFrom.Value.ToShortDateString() +
                                    " по " + model.DateTo.Value.ToShortDateString(),
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phrasePeriod)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(5)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160, 100, 100 });
            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);

            table.AddCell(new PdfPCell(new Phrase("Клиент", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Услуга", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Запчасти", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Количество", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Стоимость", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            //заполняем таблицу
            var list = GetBuyerBuys(model);
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.Count; i++)
            {

                cell = new PdfPCell(new Phrase(list[i].DateCreate.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Colspan = 5,
                    Border = 0
                };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].BuyerName, fontForCells));
                table.AddCell(cell);

                int count = 1;
                foreach (var serve in list[i].ServesInParts)
                {

                   

                    cell = new PdfPCell(new Phrase(serve.Item1.ToString(), fontForCells))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Colspan = 4
                    };
                    table.AddCell(cell);
                  
                    foreach (var part in serve.Item2)
                    {

                        cell = new PdfPCell(new Phrase(part.PartName, fontForCells))
                        {
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            Colspan = 3      
                        };
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(part.Count.ToString(), fontForCells))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            Colspan = 1
                        };
                        table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(part.PartPrice.ToString(), fontForCells))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            Colspan = 1
                        };
                        table.AddCell(cell);

                    }
                    cell = new PdfPCell(new Phrase(serve.Item3.ToString(), fontForCells))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT,
                        Colspan = 5
                    };
                    table.AddCell(cell);

                    if (count < (list[i].ServesInParts.Count())) {
                        cell = new PdfPCell(new Phrase("", fontForCells));
                        table.AddCell(cell);
                    }                  
                    count++;
                }
                cell = new PdfPCell(new Phrase(list[i].TotalCount.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Colspan = 4,
                    Border = 0
                };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].TotalSum.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Colspan = 5,
                    Border = 0
                };
                table.AddCell(cell);
            }
            //вставляем таблицу
            doc.Add(table);

            doc.Close();
        }
    }
}
