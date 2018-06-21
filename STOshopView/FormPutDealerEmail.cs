using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOshopView
{
    public partial class FormPutDealerEmail : Form
    {
        public string Model { set { model = value; } get { return model; } }

        private string model;

        public FormPutDealerEmail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonGotEmail_Click(object sender, EventArgs e)
        {
            string mail = textBoxDealerMail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    model = mail;
                    MessageBox.Show("Ок", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            

        }
    }
}
