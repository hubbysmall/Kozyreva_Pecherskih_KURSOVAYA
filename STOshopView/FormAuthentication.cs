using STOshopService.BindingModels;
using STOshopService.Interfaces;
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
    public partial class FormAuthentication : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMain_Order_Service service;

        public FormAuthentication(IMain_Order_Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text)
                || string.IsNullOrEmpty(textBoxPsw.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                AdminBindingModel adm = new AdminBindingModel
                {
                    AdminPassword = textBoxPsw.Text,
                    AdminName = textBoxName.Text
                };
                bool exist = service.checkAdminIfExist(adm);
                if (exist)
                {
                    service.setCurrentAdmin(adm);
                    MessageBox.Show("Вы вошли", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                    var form = Container.Resolve<FormMain>();
                    form.Show();
                }
                else {
                    MessageBox.Show("Данные не соответствуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
