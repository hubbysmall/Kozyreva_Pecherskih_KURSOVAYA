using STOshopService.BindingModels;
using STOshopService.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using Unity;
using Unity.Attributes;

namespace WpfSTOshop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IClientService service;

        int idCurrentClient;


        public MainWindow(IClientService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                ClientBindingModel client = service.GetElement(textBoxLogin.Text);
                if (client != null)
                {
                    if (PasswordBox.Password == client.ClientPassword)
                    {
                        idCurrentClient = client.Id;
                        var form = Container.Resolve<MenuWindow>(new Unity.Resolution.ResolverOverride[]{
                            new Unity.Resolution.ParameterOverride("idClient", idCurrentClient)});
                        this.Close();
                        if (form.ShowDialog() == true)
                        { }
                    }
                    else
                    {
                        throw new Exception("Неправильный пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonRegistr_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<RegistrationWindow>();
            if (form.ShowDialog() == true)
            {

            }
        }

        private int getCurrentClient()
        {
            return idCurrentClient;
        }



    }
}
