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
    public partial class FormHalls : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IHallService service;

        public FormHalls(IHallService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormStocks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<HallViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewHalls.DataSource = list;
                    dataGridViewHalls.Columns[0].Visible = false;
                    dataGridViewHalls.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAddHall_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormHall>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpdHall_Click(object sender, EventArgs e)
        {
            if (dataGridViewHalls.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormHall>();
                form.Id = Convert.ToInt32(dataGridViewHalls.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelHall_Click(object sender, EventArgs e)
        {
            if (dataGridViewHalls.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewHalls.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        service.DelHall(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefHall_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
