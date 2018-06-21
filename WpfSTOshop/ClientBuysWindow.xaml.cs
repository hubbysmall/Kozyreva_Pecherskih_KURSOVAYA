﻿using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using Unity.Attributes;

namespace WpfSTOshop
{
    /// <summary>
    /// Логика взаимодействия для ClientBuysWindow.xaml
    /// </summary>
    public partial class ClientBuysWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IReportClientService service;

        ClientViewModel client;

        public ClientBuysWindow(IReportClientService service, ClientViewModel Client)
        {
            InitializeComponent();
            this.service = service;
            client = Client;
        }

        private void buttonMake_Click(object sender, RoutedEventArgs e)
        {
            if (dateTimePickerFrom.SelectedDate >= dateTimePickerTo.SelectedDate)
            {
                System.Windows.MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                ObservableCollection<Class1> collection = new ObservableCollection<Class1>();
                collection.Clear();
                dataGridView.ItemsSource = collection;
                var dict = service.GetClientBuys(new ReportClientBindingModel
                {
                    DateFrom = dateTimePickerFrom.SelectedDate,
                    DateTo = dateTimePickerTo.SelectedDate
                }, client.Id);
                if (dict != null)
                {
                    foreach (var buy in dict)
                    {
                        collection.Add(new Class1() { DateCreate = buy.DateCreate.ToString(), Serve = "", Part = "", Sum = "" });
                        foreach (var serve in buy.Serve_Parts)
                        {
                            collection.Add(new Class1() { DateCreate = "", Serve = serve.Item1, Part = "", Sum = "" });
                            foreach (var servePart in serve.Item2)
                            {
                                collection.Add(new Class1() { DateCreate = "", Serve = "", Part = servePart.PartName, Sum = "" });
                            }
                            collection.Add(new Class1() { DateCreate = "", Serve = "Стоимость услуги", Part = "", Sum = serve.Item3.ToString() });
                        }
                        collection.Add(new Class1() { DateCreate = "", Serve = "", Part = "", Sum = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service.SaveClientBuy(new ReportClientBindingModel
                {
                    FileName = "D:\\MY_TEMPORARY\\file.pdf",
                    DateFrom = dateTimePickerFrom.SelectedDate,
                    DateTo = dateTimePickerTo.SelectedDate
                }, client.Id);
                String mailClient = client.ClientMail;
                MailAddress fromMailAddress = new MailAddress("LabWork15kafIS@gmail.com", "Anastasiya");
                MailAddress toAddress = new MailAddress(mailClient, "Like"); //кому отправлять

                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {

                    mailMessage.Subject = "Отчет";
                    mailMessage.Body = "Прикрепленный файл";
                    Attachment sendFile = new Attachment("D:\\MY_TEMPORARY\\file.pdf");
                    mailMessage.Attachments.Add(sendFile);

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "passlab15");

                    smtpClient.Send(mailMessage);
                    System.Windows.MessageBox.Show("Отправлено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
    public class Class1
    {
        public string DateCreate { get; set; }

        public string Serve { get; set; }

        public string Part { get; set; }

        public string Sum { get; set; }
    }
}

