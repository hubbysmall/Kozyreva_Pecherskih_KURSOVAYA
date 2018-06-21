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
    public partial class Serves : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IServeService service;

        public Serves(IServeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<ServeViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewServes.DataSource = list;
                    dataGridViewServes.Columns[0].Visible = false;
                    dataGridViewServes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddServe_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServe>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonUpdServe_Click(object sender, EventArgs e)
        {
            if (dataGridViewServes.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormServe>();
                form.Id = Convert.ToInt32(dataGridViewServes.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelServe_Click(object sender, EventArgs e)
        {
            if (dataGridViewServes.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewServes.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        service.DelServe(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefServes_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
