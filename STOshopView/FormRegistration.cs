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
    public partial class FormRegistration : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMain_Order_Service service;

        public FormRegistration(IMain_Order_Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxMail.Text) || string.IsNullOrEmpty(textBoxName.Text)
                || string.IsNullOrEmpty(textBoxPsw.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {                      
                service.addNewAdmin(new AdminBindingModel
                {
                    AdminMail = TextBoxMail.Text,
                    AdminPassword = textBoxPsw.Text,
                    AdminName = textBoxName.Text
                });
               
                MessageBox.Show("Вы зарегестрированы", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
                var form = Container.Resolve<FormMain>();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
