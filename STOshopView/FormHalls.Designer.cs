namespace STOshopView
{
    partial class FormHalls
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
            this.dataGridViewHalls = new System.Windows.Forms.DataGridView();
            this.buttonRefHall = new System.Windows.Forms.Button();
            this.buttonDelHall = new System.Windows.Forms.Button();
            this.buttonUpdHall = new System.Windows.Forms.Button();
            this.buttonAddHall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHalls)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHalls
            // 
            this.dataGridViewHalls.AllowUserToAddRows = false;
            this.dataGridViewHalls.AllowUserToDeleteRows = false;
            this.dataGridViewHalls.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewHalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHalls.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewHalls.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHalls.Name = "dataGridViewHalls";
            this.dataGridViewHalls.ReadOnly = true;
            this.dataGridViewHalls.Size = new System.Drawing.Size(267, 326);
            this.dataGridViewHalls.TabIndex = 7;
            // 
            // buttonRefHall
            // 
            this.buttonRefHall.Location = new System.Drawing.Point(284, 138);
            this.buttonRefHall.Name = "buttonRefHall";
            this.buttonRefHall.Size = new System.Drawing.Size(75, 23);
            this.buttonRefHall.TabIndex = 17;
            this.buttonRefHall.Text = "Обновить";
            this.buttonRefHall.UseVisualStyleBackColor = true;
            this.buttonRefHall.Click += new System.EventHandler(this.buttonRefHall_Click);
            // 
            // buttonDelHall
            // 
            this.buttonDelHall.Location = new System.Drawing.Point(284, 100);
            this.buttonDelHall.Name = "buttonDelHall";
            this.buttonDelHall.Size = new System.Drawing.Size(75, 23);
            this.buttonDelHall.TabIndex = 16;
            this.buttonDelHall.Text = "Удалить";
            this.buttonDelHall.UseVisualStyleBackColor = true;
            this.buttonDelHall.Click += new System.EventHandler(this.buttonDelHall_Click);
            // 
            // buttonUpdHall
            // 
            this.buttonUpdHall.Location = new System.Drawing.Point(284, 51);
            this.buttonUpdHall.Name = "buttonUpdHall";
            this.buttonUpdHall.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdHall.TabIndex = 15;
            this.buttonUpdHall.Text = "Изменить";
            this.buttonUpdHall.UseVisualStyleBackColor = true;
            this.buttonUpdHall.Click += new System.EventHandler(this.buttonUpdHall_Click);
            // 
            // buttonAddHall
            // 
            this.buttonAddHall.Location = new System.Drawing.Point(284, 12);
            this.buttonAddHall.Name = "buttonAddHall";
            this.buttonAddHall.Size = new System.Drawing.Size(75, 23);
            this.buttonAddHall.TabIndex = 14;
            this.buttonAddHall.Text = "Добавить";
            this.buttonAddHall.UseVisualStyleBackColor = true;
            this.buttonAddHall.Click += new System.EventHandler(this.buttonAddHall_Click);
            // 
            // FormHalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 326);
            this.Controls.Add(this.buttonRefHall);
            this.Controls.Add(this.buttonDelHall);
            this.Controls.Add(this.buttonUpdHall);
            this.Controls.Add(this.buttonAddHall);
            this.Controls.Add(this.dataGridViewHalls);
            this.Name = "FormHalls";
            this.Text = "FormHalls";
            this.Load += new System.EventHandler(this.FormStocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHalls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHalls;
        private System.Windows.Forms.Button buttonRefHall;
        private System.Windows.Forms.Button buttonDelHall;
        private System.Windows.Forms.Button buttonUpdHall;
        private System.Windows.Forms.Button buttonAddHall;
    }
}