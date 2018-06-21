using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Data.Entity;


namespace STOshopService.realizationDB
{
    public class ReportClientServiceDB : IReportClientService
    {
        private STOshopDBContext context;

        public ReportClientServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public void SaveServePriceDoc(ReportClientBindingModel model)
        {
            if (File.Exists(model.FileName))
            {
                File.Delete(model.FileName);
            }

            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                    winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                //задаем текст
                range.Text = "Список цен всех услуг";
                //шрифт
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //абзац
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();

                var serves = context.Serves.ToList();
                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, serves.Count, 2, ref missing, ref missing);

                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;

                for (int i = 0; i < serves.Count; ++i)
                {
                    table.Cell(i + 1, 1).Range.Text = serves[i].ServeName;
                    table.Cell(i + 1, 2).Range.Text = serves[i].MyPriceAndParts.ToString();
                }
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;

                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;

                range.Text = "Дата: " + DateTime.Now.ToLongDateString();

                font = range.Font;
                font.Size = 12;
                font.Name = "Times New Roman";

                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;

                range.InsertParagraphAfter();
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(model.FileName, ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }

        public void SaveServePriceExcel(ReportClientBindingModel model)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                //или создаем excel-файл, или открываем существующий
                if (File.Exists(model.FileName))
                {
                    excel.Workbooks.Open(model.FileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(model.FileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                excelworksheet.Cells.Clear();
                //excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                //excelworksheet.PageSetup.CenterHorizontally = true;
                //excelworksheet.PageSetup.CenterVertically = true;
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "C1");
                excelcells.Merge(Type.Missing);
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Список цен всех услуг";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("A2", "C2");
                excelcells.Merge(Type.Missing);
                excelcells.Value2 = "на " + DateTime.Now.ToShortDateString();
                excelcells.RowHeight = 20;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;
                excelcells = excelcells.get_Offset(1, 0);
                excelcells.Value2 = "Название услуги";
                excelcells = excelcells.get_Offset(0, 1);
                excelcells.Value2 = "Цена";
                excelcells.Font.Bold = true;


                var serves = context.Serves.ToList();
                if (serves != null)
                {
                    excelcells = excelworksheet.get_Range("B3", "B3");
                    foreach (var elem in serves)
                    {
                        excelcells = excelcells.get_Offset(1, -1);
                        excelcells.ColumnWidth = 18;
                        excelcells.Value2 = elem.ServeName;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.Value2 = elem.MyPriceAndParts;
                        excelcells.Font.Bold = true;
                    }
                }
                excel.Workbooks[1].Save();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                excel.Quit();
            }
        }

        public void SaveClientBuy(ReportClientBindingModel model, int idClient)
        {

            //из ресурсов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }
            //открываем файл
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //заголовок
            var phraseTitle = new Phrase("Заказы клиента",
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
            PdfPTable table = new PdfPTable(6)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 140, 160, 100, 100, 140 });
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
            var list = GetClientBuys(model, idClient);
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
                cell = new PdfPCell(new Phrase(list[i].ClientName, fontForCells));
                table.AddCell(cell);
                foreach (var serve in list[i].Serve_Parts)
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
                }
                cell = new PdfPCell(new Phrase(list[i].TotalCount.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Colspan = 4,
                    Border = 0
                };
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Sum.ToString(), fontForCellBold))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Colspan = 5,
                    Border = 0
                };
                table.AddCell(cell);
            }
            //вставляем таблицу
            doc.Add(table);

            doc.Close();

        }


        public List<ClientBuysModel> GetClientBuys(ReportClientBindingModel model, int idClient)
        {
            return context.Buys.ToList()
                            .Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo && rec.ClientId == idClient)
                            .GroupJoin(context.Buy_Serves
                                     .Include(rec => rec.Serve).ToList(),
                                     buy => buy,
                                     buyServe => buyServe.Buy,
                                     (buy, buyServeList) => new ClientBuysModel
                                     {
                                         ClientName = context.Clients.FirstOrDefault(rec => rec.Id == buy.ClientId).ClientFIO,
                                         TotalCount = buy.TotalCount,
                                         Sum = buy.TotalSum,
                                         DateCreate = buy.DateCreate,
                                         Serve_Parts = buyServeList.Select(r => new Tuple<string, List<Serve_PartViewModel>, int>(r.Serve.ServeName, GetPartsListByServeId(r.ServeId), r.Serve.MyPriceAndParts))
                                     }).ToList();

        }


        public List<Serve_PartViewModel> GetPartsListByServeId(int ServeId)
        {
            List<Serve_PartViewModel> result = context.Serve_Parts
                .Where(rec => rec.ServeId == ServeId)
                .Select(rec => new Serve_PartViewModel
                {
                    Id = rec.Id,
                    ServeId = rec.ServeId,
                    PartId = rec.PartId,
                    PartName = rec.Part.PartName,
                    Count = rec.Count,
                    PartPrice = rec.Part.PartPrice
                }).ToList();

            return result;
        }

    }
}
