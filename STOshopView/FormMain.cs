﻿using STOshopService.Interfaces;
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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMain_Order_Service service;

        public FormMain(IMain_Order_Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///////////
        }

        private void запчастиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormParts>();
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<Serves>();
            form.ShowDialog();

        }

        private void контрольСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormShowExhaust_MakeOrder>();
            form.ShowDialog();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormHalls>();
            form.ShowDialog();
        }

        private void просмотрЗаявокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLookAdminOrders>();
            form.ShowDialog();
        }

        private void просмотрРемонтовКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormLookBuyerBuys>();
            form.ShowDialog();
        }
    }
}
