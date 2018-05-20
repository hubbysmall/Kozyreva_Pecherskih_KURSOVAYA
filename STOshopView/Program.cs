using STOshopService;
using STOshopService.Interfaces;
using STOshopService.realizationDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace STOshopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, STOshopDBContext>(new HierarchicalLifetimeManager()); 
            currentContainer.RegisterType<IPartService, PartServiceDB>(new HierarchicalLifetimeManager());
           
            currentContainer.RegisterType<IServeService, ServeServiceDB>(new HierarchicalLifetimeManager());
          
            currentContainer.RegisterType<IMain_Order_Service, Main_Order_ServiceDB>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IHallService, HallServiceDB>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
