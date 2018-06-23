namespace STOshopView
{
    partial class FormServe
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxServePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServeName = new System.Windows.Forms.TextBox();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.buttonRefPart = new System.Windows.Forms.Button();
            this.buttonDelPart = new System.Windows.Forms.Button();
            this.buttonUpdPart = new System.Windows.Forms.Button();
            this.buttonAddPart = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUpdTotalPrice = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(365, 41);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(365, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxServePrice
            // 
            this.textBoxServePrice.Location = new System.Drawing.Point(69, 36);
            this.textBoxServePrice.Name = "textBoxServePrice";
            this.textBoxServePrice.Size = new System.Drawing.Size(235, 20);
            this.textBoxServePrice.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Цена";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название";
            // 
            // textBoxServeName
            // 
            this.textBoxServeName.Location = new System.Drawing.Point(69, 6);
            this.textBoxServeName.Name = "textBoxServeName";
            this.textBoxServeName.Size = new System.Drawing.Size(235, 20);
            this.textBoxServeName.TabIndex = 6;
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.buttonRefPart);
            this.groupBoxComponents.Controls.Add(this.buttonDelPart);
            this.groupBoxComponents.Controls.Add(this.buttonUpdPart);
            this.groupBoxComponents.Controls.Add(this.buttonAddPart);
            this.groupBoxComponents.Controls.Add(this.dataGridView);
            this.groupBoxComponents.Location = new System.Drawing.Point(15, 85);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(467, 250);
            this.groupBoxComponents.TabIndex = 12;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Запчасти для услуги";
            this.groupBoxComponents.Enter += new System.EventHandler(this.groupBoxComponents_Enter);
            // 
            // buttonRefPart
            // 
            this.buttonRefPart.Location = new System.Drawing.Point(378, 148);
            this.buttonRefPart.Name = "buttonRefPart";
            this.buttonRefPart.Size = new System.Drawing.Size(75, 23);
            this.buttonRefPart.TabIndex = 4;
            this.buttonRefPart.Text = "Обновить";
            this.buttonRefPart.UseVisualStyleBackColor = true;
            this.buttonRefPart.Click += new System.EventHandler(this.buttonRefPart_Click);
            // 
            // buttonDelPart
            // 
            this.buttonDelPart.Location = new System.Drawing.Point(378, 107);
            this.buttonDelPart.Name = "buttonDelPart";
            this.buttonDelPart.Size = new System.Drawing.Size(75, 23);
            this.buttonDelPart.TabIndex = 3;
            this.buttonDelPart.Text = "Удалить";
            this.buttonDelPart.UseVisualStyleBackColor = true;
            this.buttonDelPart.Click += new System.EventHandler(this.buttonDelPart_Click);
            // 
            // buttonUpdPart
            // 
            this.buttonUpdPart.Location = new System.Drawing.Point(378, 66);
            this.buttonUpdPart.Name = "buttonUpdPart";
            this.buttonUpdPart.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdPart.TabIndex = 2;
            this.buttonUpdPart.Text = "Изменить";
            this.buttonUpdPart.UseVisualStyleBackColor = true;
            this.buttonUpdPart.Click += new System.EventHandler(this.buttonUpdPart_Click);
            // 
            // buttonAddPart
            // 
            this.buttonAddPart.Location = new System.Drawing.Point(378, 28);
            this.buttonAddPart.Name = "buttonAddPart";
            this.buttonAddPart.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPart.TabIndex = 1;
            this.buttonAddPart.Text = "Добавить";
            this.buttonAddPart.UseVisualStyleBackColor = true;
            this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(350, 231);
            this.dataGridView.TabIndex = 0;
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(283, 358);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.Size = new System.Drawing.Size(115, 20);
            this.textBoxTotalPrice.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Цена с учетом запчастей";
            // 
            // buttonUpdTotalPrice
            // 
            this.buttonUpdTotalPrice.Location = new System.Drawing.Point(407, 356);
            this.buttonUpdTotalPrice.Name = "buttonUpdTotalPrice";
            this.buttonUpdTotalPrice.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdTotalPrice.TabIndex = 5;
            this.buttonUpdTotalPrice.Text = "Обновить";
            this.buttonUpdTotalPrice.UseVisualStyleBackColor = true;
            this.buttonUpdTotalPrice.Click += new System.EventHandler(this.buttonUpdTotalPrice_Click);
            // 
            // FormServe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 396);
            this.Controls.Add(this.buttonUpdTotalPrice);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxServePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxServeName);
            this.Name = "FormServe";
            this.Text = "FormServe";
            this.Load += new System.EventHandler(this.FormServe_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxServePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServeName;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.Button buttonRefPart;
        private System.Windows.Forms.Button buttonDelPart;
        private System.Windows.Forms.Button buttonUpdPart;
        private System.Windows.Forms.Button buttonAddPart;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUpdTotalPrice;
    }
}