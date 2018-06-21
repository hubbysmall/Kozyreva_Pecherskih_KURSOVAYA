namespace STOshopView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запчастиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.механикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрольСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрЗаявокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрРемонтовКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.контрольСкладовToolStripMenuItem,
            this.просмотрЗаявокToolStripMenuItem,
            this.просмотрРемонтовКлиентовToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запчастиToolStripMenuItem,
            this.услугиToolStripMenuItem,
            this.механикиToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            this.справочникиToolStripMenuItem.Click += new System.EventHandler(this.справочникиToolStripMenuItem_Click);
            // 
            // запчастиToolStripMenuItem
            // 
            this.запчастиToolStripMenuItem.Name = "запчастиToolStripMenuItem";
            this.запчастиToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.запчастиToolStripMenuItem.Text = "Запчасти";
            this.запчастиToolStripMenuItem.Click += new System.EventHandler(this.запчастиToolStripMenuItem_Click);
            // 
            // услугиToolStripMenuItem
            // 
            this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            this.услугиToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.услугиToolStripMenuItem.Text = "Услуги";
            this.услугиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // механикиToolStripMenuItem
            // 
            this.механикиToolStripMenuItem.Name = "механикиToolStripMenuItem";
            this.механикиToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.механикиToolStripMenuItem.Text = "Механики";
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // контрольСкладовToolStripMenuItem
            // 
            this.контрольСкладовToolStripMenuItem.Name = "контрольСкладовToolStripMenuItem";
            this.контрольСкладовToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.контрольСкладовToolStripMenuItem.Text = "Контроль складов";
            this.контрольСкладовToolStripMenuItem.Click += new System.EventHandler(this.контрольСкладовToolStripMenuItem_Click);
            // 
            // просмотрЗаявокToolStripMenuItem
            // 
            this.просмотрЗаявокToolStripMenuItem.Name = "просмотрЗаявокToolStripMenuItem";
            this.просмотрЗаявокToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.просмотрЗаявокToolStripMenuItem.Text = "Просмотр заявок";
            this.просмотрЗаявокToolStripMenuItem.Click += new System.EventHandler(this.просмотрЗаявокToolStripMenuItem_Click);
            // 
            // просмотрРемонтовКлиентовToolStripMenuItem
            // 
            this.просмотрРемонтовКлиентовToolStripMenuItem.Name = "просмотрРемонтовКлиентовToolStripMenuItem";
            this.просмотрРемонтовКлиентовToolStripMenuItem.Size = new System.Drawing.Size(187, 20);
            this.просмотрРемонтовКлиентовToolStripMenuItem.Text = "Просмотр ремонтов клиентов";
            this.просмотрРемонтовКлиентовToolStripMenuItem.Click += new System.EventHandler(this.просмотрРемонтовКлиентовToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запчастиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem услугиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem механикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контрольСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрЗаявокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрРемонтовКлиентовToolStripMenuItem;
    }
}