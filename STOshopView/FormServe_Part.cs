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
    public partial class FormServe_Part : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public Serve_PartViewModel Model { set { model = value; } get { return model; } }

        private readonly IPartService service;

        private Serve_PartViewModel model;

        public FormServe_Part(IPartService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormServe_Part_Load(object sender, EventArgs e)
        {
            try
            {
                List<PartViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxComponentParts.DisplayMember = "PartName";
                    comboBoxComponentParts.ValueMember = "Id";
                    comboBoxComponentParts.DataSource = list;
                    comboBoxComponentParts.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxComponentParts.Enabled = false;
                comboBoxComponentParts.SelectedValue = model.PartId;
                textBoxPartsCount.Text = model.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPartsCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponentParts.SelectedValue == null)
            {
                MessageBox.Show("Выберите запчасть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new Serve_PartViewModel
                    {
                        PartId = Convert.ToInt32(comboBoxComponentParts.SelectedValue),
                        PartName = comboBoxComponentParts.Text,
                        Count = Convert.ToInt32(textBoxPartsCount.Text),
                        PartPrice = service.GetPartPrice(Convert.ToInt32(comboBoxComponentParts.SelectedValue))
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxPartsCount.Text);
                }
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
