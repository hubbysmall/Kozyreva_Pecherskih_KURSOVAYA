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
    public partial class FormLookBuyerBuys : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IReportService service;
        private readonly IBuyerServiceLimited serviceAddit;

        public FormLookBuyerBuys(IReportService service, IBuyerServiceLimited serv)
        {
            InitializeComponent();
            this.service = service;
            this.serviceAddit = serv;
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
                var dict = service.GetBuyerBuys(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });
                if (dict != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var buyElem in dict)
                    {
                        dataGridView1.Rows.Add(new object[] { buyElem.DateCreate, "", "" });
                        dataGridView1.Rows.Add(new object[] { buyElem.BuyerName, "", "" });
                        foreach (var boughtServe in buyElem.ServesInParts)
                        {
                            dataGridView1.Rows.Add(new object[] { "", "", boughtServe.Item1}); //serveName
                            foreach (var servePart in boughtServe.Item2)
                            {
                                dataGridView1.Rows.Add(new object[] { "", "", "", servePart.PartName, servePart.Count, servePart.PartPrice});
                                //dataGridView1.Rows.Add(new object[] { "", "", "", "", servePart.Count});
                                //dataGridView1.Rows.Add(new object[] { "", "", "", "", "", servePart.PartPrice});
                            }
                            dataGridView1.Rows.Add(new object[] { "Стоимость услуги", "", "", "", "", boughtServe.Item3 });
                        }
                        dataGridView1.Rows.Add(new object[] { "Услуг всего", "", "", "", buyElem.TotalCount });
                        dataGridView1.Rows.Add(new object[] { "Заплачено", "", "", "", "", buyElem.TotalSum });
                        dataGridView1.Rows.Add(new object[] { "******************" });
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
                    service.SaveBuyerBuys(new ReportBindingModel
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

        private void btnGenTestData_Click(object sender, EventArgs e)
        {
            serviceAddit.takeRandomBuyerInfo();
        }
    }
}
