namespace STOshopView
{
    partial class FormServe_Part
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
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxComponentParts = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxPartsCount = new System.Windows.Forms.TextBox();
            this.labelComponent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(21, 57);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 14;
            this.labelCount.Text = "Количество:";
            // 
            // comboBoxComponentParts
            // 
            this.comboBoxComponentParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComponentParts.FormattingEnabled = true;
            this.comboBoxComponentParts.Location = new System.Drawing.Point(96, 27);
            this.comboBoxComponentParts.Name = "comboBoxComponentParts";
            this.comboBoxComponentParts.Size = new System.Drawing.Size(396, 21);
            this.comboBoxComponentParts.TabIndex = 12;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(227, 80);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(146, 80);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxPartsCount
            // 
            this.textBoxPartsCount.Location = new System.Drawing.Point(96, 54);
            this.textBoxPartsCount.Name = "textBoxPartsCount";
            this.textBoxPartsCount.Size = new System.Drawing.Size(217, 20);
            this.textBoxPartsCount.TabIndex = 15;
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(21, 30);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(48, 13);
            this.labelComponent.TabIndex = 13;
            this.labelComponent.Text = "Зачасть";
            // 
            // FormServe_Part
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 144);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxComponentParts);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxPartsCount);
            this.Controls.Add(this.labelComponent);
            this.Name = "FormServe_Part";
            this.Text = "FormServe_Part";
            this.Load += new System.EventHandler(this.FormServe_Part_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBoxComponentParts;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxPartsCount;
        private System.Windows.Forms.Label labelComponent;
    }
}