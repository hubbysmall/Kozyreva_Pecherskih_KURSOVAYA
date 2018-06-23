using STOshopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace STOshopService
{
    [Table("STOshopDatabase")]
    public class STOshopDBContext : DbContext
    {
        public STOshopDBContext()
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<Buy> Buys { get; set; }

        public virtual DbSet<Buy_Serve> Buy_Serves { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Serve> Serves { get; set; }

        public virtual DbSet<Serve_Part> Serve_Parts { get; set; }

        public virtual DbSet<Hall> Halls { get; set; }

        public virtual DbSet<Hall_Part> Hall_Parts { get; set; }

        public virtual DbSet<Order_Part> Order_Parts { get; set; }

    }
}
