using STOshopService.BindingModels;
using STOshopService.Interfaces;
using STOshopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Unity;
using Unity.Attributes;

namespace WpfSTOshop
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }

        private readonly IMainClientService service;
        private readonly IReportClientService reportService;

        private int? id;

        int idClient;
        ClientViewModel client;

        ObservableCollection<ServeViewModel> listChoice;


        public MenuWindow(int idClient, IMainClientService service, IReportClientService reportService)
        {
            InitializeComponent();
            this.service = service;
            this.reportService = reportService;
            listChoice = new ObservableCollection<ServeViewModel>();
            this.idClient = idClient;
            client = service.getClient(idClient);
            TextBoxClientName.Text += client.ClientFIO;
            Loaded += MenuWindow_Load;
        }

        private void MenuWindow_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<ServeViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView.ItemsSource = list;
                    dataGridView.Columns[0].Visibility = Visibility.Hidden;
                    dataGridView.Columns[2].Visibility = Visibility.Hidden;
                    dataGridView.Columns[4].Visibility = Visibility.Hidden;
                    dataGridView.Columns[1].Width = 180;
                    dataGridView.Columns[3].Width = DataGridLength.Auto;
                    dataGridView.Columns[1].Header = "Услуга";
                    dataGridView.Columns[3].Header = "Цена";
                }


                int price = 0;
                for (int i = 0; i < listChoice.Count; i++)
                {
                    price += listChoice[i].MyPriceAndParts;
                }
                TextBoxSum.Text = "" + price;
                if (price > 0)
                {
                    buttonCreateOrder.IsEnabled = true;
                }
                else
                {
                    buttonCreateOrder.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItem != null)
            {
                try
                {
                    int id = ((ServeViewModel)dataGridView.SelectedItem).Id;
                    ServeViewModel serveChoice = service.GetElement(id);
                    if (!listChoice.Any(x => x.Id == serveChoice.Id))
                    {
                        listChoice.Add(serveChoice);
                        dataGridChoice.ItemsSource = listChoice;
                        dataGridChoice.Columns[0].Visibility = Visibility.Hidden;
                        dataGridChoice.Columns[2].Visibility = Visibility.Hidden;
                        dataGridChoice.Columns[4].Visibility = Visibility.Hidden;
                        dataGridChoice.Columns[1].Width = 180;
                        dataGridChoice.Columns[3].Width = DataGridLength.Auto;
                        dataGridChoice.Columns[1].Header = "Услуга";
                        dataGridChoice.Columns[3].Header = "Цена";

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Услуга уже добавлена", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonDel_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridChoice.SelectedItem != null)
            {
                listChoice.Remove(dataGridChoice.SelectedItem as ServeViewModel);
                LoadData();
            }
        }

        private void buttonSaveDOC_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    reportService.SaveServePriceDoc(new ReportClientBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonSaveExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    reportService.SaveServePriceExcel(new ReportClientBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ServeViewModel> listChoices = new List<ServeViewModel>();
                for (int i = 0; i < listChoice.Count; i++)
                {
                    listChoices.Add(listChoice[i]);
                }
                service.CreateBuy(new BuyBindingModel
                {
                    ClientId = client.Id,
                    Sum = Convert.ToInt32(TextBoxSum.Text)
                }, listChoices);
                MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                listChoice.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonGetReport_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ClientBuysWindow>(new Unity.Resolution.ResolverOverride[]{
                            new Unity.Resolution.ParameterOverride("Client", client)});
            if (form.ShowDialog() == true)
            { }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<MainWindow>();
            DialogResult = false;
            this.Close();
            if (form.ShowDialog() == true)
            { }
        }
    }
}
