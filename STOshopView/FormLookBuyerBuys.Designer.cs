namespace STOshopView
{
    partial class FormLookBuyerBuys
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
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.buttonShowReport = new System.Windows.Forms.Button();
            this.buttonPDFsave = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPartQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenTestData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(158, 12);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerTo.TabIndex = 8;
            // 
            // buttonShowReport
            // 
            this.buttonShowReport.Location = new System.Drawing.Point(391, 13);
            this.buttonShowReport.Name = "buttonShowReport";
            this.buttonShowReport.Size = new System.Drawing.Size(151, 23);
            this.buttonShowReport.TabIndex = 7;
            this.buttonShowReport.Text = "Вывести";
            this.buttonShowReport.UseVisualStyleBackColor = true;
            this.buttonShowReport.Click += new System.EventHandler(this.buttonShowReport_Click);
            // 
            // buttonPDFsave
            // 
            this.buttonPDFsave.Location = new System.Drawing.Point(548, 13);
            this.buttonPDFsave.Name = "buttonPDFsave";
            this.buttonPDFsave.Size = new System.Drawing.Size(136, 23);
            this.buttonPDFsave.TabIndex = 6;
            this.buttonPDFsave.Text = "Сохранить в PDF";
            this.buttonPDFsave.UseVisualStyleBackColor = true;
            this.buttonPDFsave.Click += new System.EventHandler(this.buttonPDFsave_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerFrom.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrderDate,
            this.ColumnClientName,
            this.ColumnServe,
            this.ColumnParts,
            this.ColumnPartQuan,
            this.ColumnTotalSum});
            this.dataGridView1.Location = new System.Drawing.Point(20, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(664, 371);
            this.dataGridView1.TabIndex = 9;
            // 
            // ColumnOrderDate
            // 
            this.ColumnOrderDate.HeaderText = "Дата оформления ";
            this.ColumnOrderDate.Name = "ColumnOrderDate";
            this.ColumnOrderDate.Width = 120;
            // 
            // ColumnClientName
            // 
            this.ColumnClientName.HeaderText = "Клиент";
            this.ColumnClientName.Name = "ColumnClientName";
            // 
            // ColumnServe
            // 
            this.ColumnServe.HeaderText = "Услуга";
            this.ColumnServe.Name = "ColumnServe";
            // 
            // ColumnParts
            // 
            this.ColumnParts.HeaderText = "Запчасти";
            this.ColumnParts.Name = "ColumnParts";
            // 
            // ColumnPartQuan
            // 
            this.ColumnPartQuan.HeaderText = "Количество";
            this.ColumnPartQuan.Name = "ColumnPartQuan";
            // 
            // ColumnTotalSum
            // 
            this.ColumnTotalSum.HeaderText = "Стоимость";
            this.ColumnTotalSum.Name = "ColumnTotalSum";
            // 
            // btnGenTestData
            // 
            this.btnGenTestData.Location = new System.Drawing.Point(310, 13);
            this.btnGenTestData.Name = "btnGenTestData";
            this.btnGenTestData.Size = new System.Drawing.Size(75, 23);
            this.btnGenTestData.TabIndex = 10;
            this.btnGenTestData.Text = "genTestData";
            this.btnGenTestData.UseVisualStyleBackColor = true;
            this.btnGenTestData.Click += new System.EventHandler(this.btnGenTestData_Click);
            // 
            // FormLookBuyerBuys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.btnGenTestData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.buttonShowReport);
            this.Controls.Add(this.buttonPDFsave);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Name = "FormLookBuyerBuys";
            this.Text = "FormLookBuyerBuys";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button buttonShowReport;
        private System.Windows.Forms.Button buttonPDFsave;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPartQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalSum;
        private System.Windows.Forms.Button btnGenTestData;
    }
}