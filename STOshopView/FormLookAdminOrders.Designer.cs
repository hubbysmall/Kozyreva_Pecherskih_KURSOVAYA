namespace STOshopView
{
    partial class FormLookAdminOrders
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrderedParts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHallName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonPDFsave = new System.Windows.Forms.Button();
            this.buttonShowReport = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrderDate,
            this.ColumnOrderedParts,
            this.ColumnHallName,
            this.ColumnTotalCount,
            this.ColumnTotalSum});
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(563, 371);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnOrderDate
            // 
            this.ColumnOrderDate.HeaderText = "Дата оформления ";
            this.ColumnOrderDate.Name = "ColumnOrderDate";
            this.ColumnOrderDate.Width = 120;
            // 
            // ColumnOrderedParts
            // 
            this.ColumnOrderedParts.HeaderText = "Заказанные запчасти";
            this.ColumnOrderedParts.Name = "ColumnOrderedParts";
            // 
            // ColumnHallName
            // 
            this.ColumnHallName.HeaderText = "Для склада";
            this.ColumnHallName.Name = "ColumnHallName";
            // 
            // ColumnTotalCount
            // 
            this.ColumnTotalCount.HeaderText = "Количество";
            this.ColumnTotalCount.Name = "ColumnTotalCount";
            // 
            // ColumnTotalSum
            // 
            this.ColumnTotalSum.HeaderText = "Стоимость";
            this.ColumnTotalSum.Name = "ColumnTotalSum";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // buttonPDFsave
            // 
            this.buttonPDFsave.Location = new System.Drawing.Point(463, 13);
            this.buttonPDFsave.Name = "buttonPDFsave";
            this.buttonPDFsave.Size = new System.Drawing.Size(113, 23);
            this.buttonPDFsave.TabIndex = 2;
            this.buttonPDFsave.Text = "Сохранить в PDF";
            this.buttonPDFsave.UseVisualStyleBackColor = true;
            this.buttonPDFsave.Click += new System.EventHandler(this.buttonPDFsave_Click);
            // 
            // buttonShowReport
            // 
            this.buttonShowReport.Location = new System.Drawing.Point(304, 13);
            this.buttonShowReport.Name = "buttonShowReport";
            this.buttonShowReport.Size = new System.Drawing.Size(151, 23);
            this.buttonShowReport.TabIndex = 3;
            this.buttonShowReport.Text = "Вывести";
            this.buttonShowReport.UseVisualStyleBackColor = true;
            this.buttonShowReport.Click += new System.EventHandler(this.buttonShowReport_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(158, 12);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(140, 20);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // FormLookAdminOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 428);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.buttonShowReport);
            this.Controls.Add(this.buttonPDFsave);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormLookAdminOrders";
            this.Text = "FormLookAdminOrders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonPDFsave;
        private System.Windows.Forms.Button buttonShowReport;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderedParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHallName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalSum;
    }
}