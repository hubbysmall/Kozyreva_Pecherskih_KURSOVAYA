using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using STOshopModel;
using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace STOshopService.realizationDB
{
    public class Main_Order_ServiceDB : IMain_Order_Service
    {
        private STOshopDBContext context;
        private string currentAdminName = "";
        private string currentAdminMail = "";

        public Main_Order_ServiceDB(STOshopDBContext context)
        {
            this.context = context;
        }

        public AdminViewModel returnCurrentAdmin() {
        
            return new AdminViewModel
            {
                AdminMail = currentAdminMail,
                AdminName = currentAdminName
            };
            
        }

        public void setCurrentAdmin(AdminBindingModel model) {
            Admin element = context.Admins.FirstOrDefault(rec => rec.AdminName == model.AdminName &&
            rec.AdminPassword == model.AdminPassword);
            currentAdminName = model.AdminName;
            currentAdminMail = element.AdminMail;
        }

        public bool checkAdminIfExist(AdminBindingModel model)
        {
            Admin element = context.Admins.FirstOrDefault(rec => rec.AdminName == model.AdminName &&
            rec.AdminPassword == model.AdminPassword);
            if (element != null)
            {
                return true;
            }
            return false;
        }

        public void addNewAdmin(AdminBindingModel model)
        {
            Admin element = context.Admins.FirstOrDefault(rec => rec.AdminName == model.AdminName);
            if (element != null)
            {
                throw new Exception("Уже есть админ с таким названием");
            }
            context.Admins.Add(new Admin
            {
                AdminMail = model.AdminMail,
                AdminName = model.AdminName,
                AdminPassword = model.AdminPassword
            });
            context.SaveChanges();           
        }

        public void SendEmail(string ToMailAddress, string subject, string text, string filePath)
        {
            string senderEmail = "LabWork15kafIS@gmail.com";
            string senderpass = "passlab15";
            MailAddress from = new MailAddress(senderEmail, senderpass);
            MailAddress to = new MailAddress(ToMailAddress);
            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage(from,to);
            SmtpClient objSmtpClient = null;

            try
            {              
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;

                Attachment sendFile = new Attachment(filePath);

                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objMailMessage.Attachments.Add(sendFile);
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new NetworkCredential(from.Address,senderpass);

                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
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

        public void SaveOrderToExcel(OrderBindingModel model, string filePAth)
        {
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                //или создаем excel-файл, или открываем существующий
                if (File.Exists(filePAth))
                {
                    excel.Workbooks.Open(filePAth, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(filePAth, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                //Получаем ссылку на лист
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                //очищаем ячейки
                excelworksheet.Cells.Clear();
                //настройки страницы
                //excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                //excelworksheet.PageSetup.CenterHorizontally = true;
                //excelworksheet.PageSetup.CenterVertically = true;
                //получаем ссылку на первые 3 ячейки
                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "D1");
                //объединяем их
                excelcells.Merge(Type.Missing);
                //задаем текст, настройки шрифта и ячейки
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Заявка";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("A2", "D2");
                excelcells.Merge(Type.Missing);
                excelcells.Value2 = "от " + DateTime.Now.ToShortDateString();
                excelcells.RowHeight = 20;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                var products = model.Order_Parts;
               
                if (products != null)
                {
                    excelcells = excelworksheet.get_Range("D2", "D2");
                    excelcells = excelcells.get_Offset(1, -3);
                    excelcells.Value2 = "название";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.Value2 = "На склад";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.Value2 = "Количество";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.Value2 = "Цена";
                    foreach (var elem in products)
                    {
                        excelcells = excelcells.get_Offset(1, -3);
                        excelcells.Value2 = elem.PartName;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.Value2 = elem.HallName;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.Value2 = elem.PartCount;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.Value2 = elem.PartPrice;                     
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

        public void SaveOrderToDoc(OrderBindingModel model, string filePAth)
        {
            if (File.Exists(filePAth))
            {
                File.Delete(filePAth);
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
                range.Text = "Заявка от "+ DateTime.Now;
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();

                var products = model.Order_Parts;
                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, products.Count, 4, ref missing, ref missing);

                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;

                for (int i = 0; i < products.Count; ++i)
                {
                    table.Cell(i + 1, 1).Range.Text = products[i].PartName;
                    table.Cell(i + 1, 2).Range.Text = products[i].HallName;
                    table.Cell(i + 1, 3).Range.Text = products[i].PartCount.ToString();
                    table.Cell(i + 1, 4).Range.Text = products[i].PartPrice.ToString();
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
                document.SaveAs(filePAth, ref fileFormat, ref missing,
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
                    PartPrice = recPC.Part.PartPrice,
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
