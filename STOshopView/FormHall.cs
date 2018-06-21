using STOshopService.BindingModels;
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
    public partial class FormHall : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IHallService service;

        private int? id;

        public FormHall(IHallService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormHall_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    HallViewModel view = service.GetHall(id.Value);
                    if (view != null)
                    {
                        textBoxHallName.Text = view.HallName;
                        dataGridPartsView.DataSource = view.Hall_Parts;
                        dataGridPartsView.Columns[0].Visible = false;
                        dataGridPartsView.Columns[1].Visible = false;
                        dataGridPartsView.Columns[2].Visible = false;
                        dataGridPartsView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            if (string.IsNullOrEmpty(textBoxHallName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdHall(new HallBindingModel
                    {
                        Id = id.Value,
                        HallName = textBoxHallName.Text
                    });
                }
                else
                {
                    service.AddHall(new HallBindingModel
                    {
                        HallName = textBoxHallName.Text
                    });
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
