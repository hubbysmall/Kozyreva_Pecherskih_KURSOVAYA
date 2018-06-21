namespace STOshopView
{
    partial class FormEnter
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
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(30, 36);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(201, 23);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "Вход";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(30, 83);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(201, 23);
            this.buttonReg.TabIndex = 1;
            this.buttonReg.Text = "Регистрация";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // FormEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 153);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.buttonEnter);
            this.Name = "FormEnter";
            this.Text = "FormEnter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonReg;
    }
}