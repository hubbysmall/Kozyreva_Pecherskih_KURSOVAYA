namespace STOshopView
{
    partial class FormShowExhaust_MakeOrder
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
            this.dataGridViewHall_Parts = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonMakeOrder = new System.Windows.Forms.Button();
            this.buttonAddHall_Parts = new System.Windows.Forms.Button();
            this.buttonUpdatePartsList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHall_Parts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHall_Parts
            // 
            this.dataGridViewHall_Parts.AllowUserToAddRows = false;
            this.dataGridViewHall_Parts.AllowUserToDeleteRows = false;
            this.dataGridViewHall_Parts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewHall_Parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHall_Parts.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewHall_Parts.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHall_Parts.Name = "dataGridViewHall_Parts";
            this.dataGridViewHall_Parts.ReadOnly = true;
            this.dataGridViewHall_Parts.Size = new System.Drawing.Size(545, 412);
            this.dataGridViewHall_Parts.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(560, 116);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonMakeOrder
            // 
            this.buttonMakeOrder.Location = new System.Drawing.Point(560, 51);
            this.buttonMakeOrder.Name = "buttonMakeOrder";
            this.buttonMakeOrder.Size = new System.Drawing.Size(75, 43);
            this.buttonMakeOrder.TabIndex = 15;
            this.buttonMakeOrder.Text = "Отправить заявку";
            this.buttonMakeOrder.UseVisualStyleBackColor = true;
            this.buttonMakeOrder.Click += new System.EventHandler(this.buttonMakeOrder_Click);
            // 
            // buttonAddHall_Parts
            // 
            this.buttonAddHall_Parts.Location = new System.Drawing.Point(560, 12);
            this.buttonAddHall_Parts.Name = "buttonAddHall_Parts";
            this.buttonAddHall_Parts.Size = new System.Drawing.Size(75, 23);
            this.buttonAddHall_Parts.TabIndex = 14;
            this.buttonAddHall_Parts.Text = "Восполнить";
            this.buttonAddHall_Parts.UseVisualStyleBackColor = true;
            this.buttonAddHall_Parts.Click += new System.EventHandler(this.buttonAddHall_Parts_Click);
            // 
            // buttonUpdatePartsList
            // 
            this.buttonUpdatePartsList.Location = new System.Drawing.Point(560, 158);
            this.buttonUpdatePartsList.Name = "buttonUpdatePartsList";
            this.buttonUpdatePartsList.Size = new System.Drawing.Size(75, 36);
            this.buttonUpdatePartsList.TabIndex = 17;
            this.buttonUpdatePartsList.Text = "Обновить список";
            this.buttonUpdatePartsList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonUpdatePartsList.UseVisualStyleBackColor = true;
            this.buttonUpdatePartsList.Click += new System.EventHandler(this.buttonUpdatePartsList_Click);
            // 
            // FormShowExhaust_MakeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 412);
            this.Controls.Add(this.buttonUpdatePartsList);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonMakeOrder);
            this.Controls.Add(this.buttonAddHall_Parts);
            this.Controls.Add(this.dataGridViewHall_Parts);
            this.Name = "FormShowExhaust_MakeOrder";
            this.Text = "FormShowExhaust_MakeOrder";
            this.Load += new System.EventHandler(this.FormShowExhaust_MakeOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHall_Parts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHall_Parts;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonMakeOrder;
        private System.Windows.Forms.Button buttonAddHall_Parts;
        private System.Windows.Forms.Button buttonUpdatePartsList;
    }
}