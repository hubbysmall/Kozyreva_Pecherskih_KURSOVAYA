using STOshopService.Interfaces;
using STOshopService.ViewModels;
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
    public partial class FormRefillHall_Part : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Hall__PartViewModel Model { set { model = value; } get { return model; } }

        private Hall__PartViewModel model;

        public int Id { set { id = value; } }

        private readonly IMain_Order_Service service;

        private int? id;

        public FormRefillHall_Part(IMain_Order_Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormRefillHall_Part_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    Hall__PartViewModel view = service.GetHall_Part(id.Value);
                    if (view != null)
                    {
                        textBoxPartsCount.Text = view.PartCount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPartsCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            try
            {
                
                    model.PartCount = Convert.ToInt32(textBoxPartsCount.Text);
                
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
