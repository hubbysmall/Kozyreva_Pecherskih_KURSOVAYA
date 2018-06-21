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
    public partial class FormLookAdminOrders : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IReportService service;

        public FormLookAdminOrders(IReportService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormLookAdminOrders_Load(object sender, EventArgs e)
        {
        }




        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /////////////////////////
        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            try
            {
                var dict = service.GetAdminOrders(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var orderElem in dict)
                    {
                        dataGridView1.Rows.Add(new object[] { orderElem.DateCreate, "", "" });
                        foreach (var orderedParts in orderElem.Parts)
                        {
                            dataGridView1.Rows.Add(new object[] { "", orderedParts.Item1, orderedParts.Item2, orderedParts.Item3, orderedParts.Item4});
                        }
                        dataGridView1.Rows.Add(new object[] { "Деталей всего", "",  "", orderElem.TotalCount });
                        dataGridView1.Rows.Add(new object[] { "Заплачено", "", "", "", orderElem.TotalSum });
                        dataGridView1.Rows.Add(new object[] {"******************"});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPDFsave_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pdf|*.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.SaveAdminOrders(new ReportBindingModel
                    {
                        FileName = sfd.FileName,
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
