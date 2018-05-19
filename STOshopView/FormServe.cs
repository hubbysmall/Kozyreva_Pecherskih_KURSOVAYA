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
    public partial class FormServe : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IServeService service;

        private int? id;

        private List<Serve_PartViewModel> Serve_Parts;

        public FormServe(IServeService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void groupBoxComponents_Enter(object sender, EventArgs e)
        {
            ////////////
        }

        private void FormServe_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ServeViewModel view = service.GetServe(id.Value);
                    if (view != null)
                    {
                        textBoxServeName.Text = view.ServeName;
                        textBoxServePrice.Text = view.Price.ToString();
                        Serve_Parts = view.Serve_Parts;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Serve_Parts = new List<Serve_PartViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (Serve_Parts != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = Serve_Parts;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServe_Part>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.ServeId = id.Value;
                    }
                    Serve_Parts.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpdPart_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormServe_Part>();
                form.Model = Serve_Parts[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Serve_Parts[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDelPart_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Serve_Parts.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefPart_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxServeName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxServePrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Serve_Parts == null || Serve_Parts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<Serve_PartBindingModel> productComponentBM = new List<Serve_PartBindingModel>();
                for (int i = 0; i < Serve_Parts.Count; ++i)
                {
                    productComponentBM.Add(new Serve_PartBindingModel
                    {
                        Id = Serve_Parts[i].Id,
                        ServeId = Serve_Parts[i].ServeId,
                        PartId = Serve_Parts[i].PartId,
                        Count = Serve_Parts[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdServe(new ServeBindingModel
                    {
                        Id = id.Value,
                        ServeName = textBoxServeName.Text,
                        MyPrice = Convert.ToInt32(textBoxServePrice.Text),
                        Serve_Parts = productComponentBM,
                        MyPriceAndParts = returnTotal()
                });
                }
                else
                {
                    service.AddServe(new ServeBindingModel
                    {
                        ServeName = textBoxServeName.Text,
                        MyPrice = Convert.ToInt32(textBoxServePrice.Text),
                        Serve_Parts = productComponentBM,
                        MyPriceAndParts = returnTotal()
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

        private void buttonUpdTotalPrice_Click(object sender, EventArgs e)
        {
            returnTotal();
        }

        private int returnTotal()
        {
            int total = Convert.ToInt32(textBoxServePrice.Text);
            foreach (Serve_PartViewModel mod in Serve_Parts)
            {
                total = total + mod.PartPrice * mod.Count;
            }
            textBoxTotalPrice.Text = total.ToString();
            return total;
        }
    }
}
