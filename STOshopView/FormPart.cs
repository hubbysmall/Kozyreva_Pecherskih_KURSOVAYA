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
    public partial class FormPart : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IPartService service;

        private int? id;

        public FormPart(IPartService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //////////////////
        }

        private void FormPart_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PartViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        textBoxPartName.Text = view.PartName;
                        textBoxPartPrice.Text = view.PartPrice.ToString();
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
            if (string.IsNullOrEmpty(textBoxPartName.Text) || string.IsNullOrEmpty(textBoxPartPrice.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdPart(new PartBindingModel
                    {
                        Id = id.Value,
                        PartName = textBoxPartName.Text,
                        PartPrice = Convert.ToInt32(textBoxPartPrice.Text)
                    });
                }
                else
                {
                    service.AddPart(new PartBindingModel
                    {
                        PartName = textBoxPartName.Text,
                        PartPrice = Convert.ToInt32(textBoxPartPrice.Text)
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
