namespace STOshopView
{
    partial class FormHall
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
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.dataGridPartsView = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxHallName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPartsView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridPartsView);
            this.groupBoxComponents.Location = new System.Drawing.Point(17, 41);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(358, 250);
            this.groupBoxComponents.TabIndex = 21;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Складируемые запчасти";
            // 
            // dataGridPartsView
            // 
            this.dataGridPartsView.AllowUserToAddRows = false;
            this.dataGridPartsView.AllowUserToDeleteRows = false;
            this.dataGridPartsView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridPartsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPartsView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridPartsView.Location = new System.Drawing.Point(3, 16);
            this.dataGridPartsView.Name = "dataGridPartsView";
            this.dataGridPartsView.ReadOnly = true;
            this.dataGridPartsView.Size = new System.Drawing.Size(350, 231);
            this.dataGridPartsView.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(279, 297);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(198, 297);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxHallName
            // 
            this.textBoxHallName.Location = new System.Drawing.Point(83, 15);
            this.textBoxHallName.Name = "textBoxHallName";
            this.textBoxHallName.Size = new System.Drawing.Size(217, 20);
            this.textBoxHallName.TabIndex = 20;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(17, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "Название:";
            // 
            // FormHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 334);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxHallName);
            this.Controls.Add(this.labelName);
            this.Name = "FormHall";
            this.Text = "FormHall";
            this.Load += new System.EventHandler(this.FormHall_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPartsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridPartsView;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxHallName;
        private System.Windows.Forms.Label labelName;
    }
}