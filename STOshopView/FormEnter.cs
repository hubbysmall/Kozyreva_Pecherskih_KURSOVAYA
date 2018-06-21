using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace STOshopView
{
    public partial class FormEnter : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormEnter()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            // FormAuthentication form = new FormAuthentication();
            var form = Container.Resolve<FormAuthentication>();
            form.Show();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {           
            this.Hide();
            var form = Container.Resolve<FormRegistration>();
            form.Show();
            //FormRegistration form = new FormRegistration();
            //form.Show();

        }
    }
}
