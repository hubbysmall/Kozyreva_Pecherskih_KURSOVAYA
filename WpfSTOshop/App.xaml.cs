using STOshopService;
using STOshopService.Interfaces;
using STOshopService.realizationDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace WpfSTOshop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            var application = new App();
            application.Run(container.Resolve<MainWindow>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, STOshopDBContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientService, ClientServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainClientService, MainClientServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportClientService, ReportClientServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBackupService, BackupServiceDB>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
