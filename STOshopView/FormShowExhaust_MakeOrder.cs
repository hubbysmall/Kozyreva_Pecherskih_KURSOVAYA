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
    public partial class FormShowExhaust_MakeOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMain_Order_Service service;

        private List<Hall__PartViewModel> Hall_Parts;

        public FormShowExhaust_MakeOrder(IMain_Order_Service service)
        {
            InitializeComponent();
            this.service = service;

            // List<Hall__PartViewModel> list = service.ShowExhaustingParts();
            Hall_Parts = service.ShowExhaustingParts();
        }

        private void FormShowExhaust_MakeOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                
                if (Hall_Parts != null)
                {
                    dataGridViewHall_Parts.DataSource = Hall_Parts;
                    dataGridViewHall_Parts.Columns[0].Visible = false;
                    dataGridViewHall_Parts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;               
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddHall_Parts_Click(object sender, EventArgs e)
        {
            if (dataGridViewHall_Parts.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormRefillHall_Part>();
                form.Id = Convert.ToInt32(dataGridViewHall_Parts.SelectedRows[0].Cells[0].Value);
                form.Model = Hall_Parts[dataGridViewHall_Parts.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Hall__PartViewModel ex = form.Model;
                    Hall_Parts[dataGridViewHall_Parts.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    dataGridViewHall_Parts.UpdateCellValue(5, dataGridViewHall_Parts.SelectedRows[0].Cells[0].RowIndex);
                }
            }
        }

        private void buttonMakeOrder_Click(object sender, EventArgs e)
        {
            try
            {
                List<Order_PartBindingModel> partsForOrder = new List<Order_PartBindingModel>();
                List<Hall_PartBindingModel> partsInHall = new List<Hall_PartBindingModel>();
                for (int i = 0; i < Hall_Parts.Count; ++i)
                {
                    if (Hall_Parts[i].PartCount > 0) {

                        partsForOrder.Add(new Order_PartBindingModel
                        {
                            Id = Hall_Parts[i].Id,
                            HallId = Hall_Parts[i].HallId,
                            PartId = Hall_Parts[i].PartId,
                            PartCount = Hall_Parts[i].PartCount
                        });
                        partsInHall.Add(new Hall_PartBindingModel
                        {
                            Id = Hall_Parts[i].Id,
                            HallId = Hall_Parts[i].HallId,
                            PartId = Hall_Parts[i].PartId,
                            Count = Hall_Parts[i].PartCount
                        });
                    }                  
                }
                service.PutOrderedPartsInHall(partsInHall);
                service.CreateOrder_AND_PutOrderedPartsInHall(new OrderBindingModel
                {
                    AdminId = 5,
                    AdminName = "TestNameAdmin",
                    TotalCount = 999999,
                    TotalSum = 66666666,
                    Order_Parts = partsForOrder         
                });
                
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

        private void buttonUpdatePartsList_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
