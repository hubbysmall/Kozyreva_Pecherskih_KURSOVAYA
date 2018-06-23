namespace STOshopView
{
    partial class Serves
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
            this.dataGridViewServes = new System.Windows.Forms.DataGridView();
            this.buttonRefServes = new System.Windows.Forms.Button();
            this.buttonDelServe = new System.Windows.Forms.Button();
            this.buttonUpdServe = new System.Windows.Forms.Button();
            this.buttonAddServe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewServes
            // 
            this.dataGridViewServes.AllowUserToAddRows = false;
            this.dataGridViewServes.AllowUserToDeleteRows = false;
            this.dataGridViewServes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewServes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServes.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewServes.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewServes.Name = "dataGridViewServes";
            this.dataGridViewServes.ReadOnly = true;
            this.dataGridViewServes.Size = new System.Drawing.Size(545, 450);
            this.dataGridViewServes.TabIndex = 6;
            // 
            // buttonRefServes
            // 
            this.buttonRefServes.Location = new System.Drawing.Point(551, 138);
            this.buttonRefServes.Name = "buttonRefServes";
            this.buttonRefServes.Size = new System.Drawing.Size(75, 23);
            this.buttonRefServes.TabIndex = 13;
            this.buttonRefServes.Text = "Обновить";
            this.buttonRefServes.UseVisualStyleBackColor = true;
            this.buttonRefServes.Click += new System.EventHandler(this.buttonRefServes_Click);
            // 
            // buttonDelServe
            // 
            this.buttonDelServe.Location = new System.Drawing.Point(551, 100);
            this.buttonDelServe.Name = "buttonDelServe";
            this.buttonDelServe.Size = new System.Drawing.Size(75, 23);
            this.buttonDelServe.TabIndex = 12;
            this.buttonDelServe.Text = "Удалить";
            this.buttonDelServe.UseVisualStyleBackColor = true;
            this.buttonDelServe.Click += new System.EventHandler(this.buttonDelServe_Click);
            // 
            // buttonUpdServe
            // 
            this.buttonUpdServe.Location = new System.Drawing.Point(551, 51);
            this.buttonUpdServe.Name = "buttonUpdServe";
            this.buttonUpdServe.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdServe.TabIndex = 11;
            this.buttonUpdServe.Text = "Изменить";
            this.buttonUpdServe.UseVisualStyleBackColor = true;
            this.buttonUpdServe.Click += new System.EventHandler(this.buttonUpdServe_Click);
            // 
            // buttonAddServe
            // 
            this.buttonAddServe.Location = new System.Drawing.Point(551, 12);
            this.buttonAddServe.Name = "buttonAddServe";
            this.buttonAddServe.Size = new System.Drawing.Size(75, 23);
            this.buttonAddServe.TabIndex = 10;
            this.buttonAddServe.Text = "Добавить";
            this.buttonAddServe.UseVisualStyleBackColor = true;
            this.buttonAddServe.Click += new System.EventHandler(this.buttonAddServe_Click);
            // 
            // Serves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 450);
            this.Controls.Add(this.buttonRefServes);
            this.Controls.Add(this.buttonDelServe);
            this.Controls.Add(this.buttonUpdServe);
            this.Controls.Add(this.buttonAddServe);
            this.Controls.Add(this.dataGridViewServes);
            this.Name = "Serves";
            this.Text = "Serves";
            this.Load += new System.EventHandler(this.FormProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewServes;
        private System.Windows.Forms.Button buttonRefServes;
        private System.Windows.Forms.Button buttonDelServe;
        private System.Windows.Forms.Button buttonUpdServe;
        private System.Windows.Forms.Button buttonAddServe;
    }
}