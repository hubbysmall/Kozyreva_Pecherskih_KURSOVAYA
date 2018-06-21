namespace STOshopView
{
    partial class FormPutDealerEmail
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDealerMail = new System.Windows.Forms.TextBox();
            this.buttonGotEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите имейл поставщика:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxDealerMail
            // 
            this.textBoxDealerMail.Location = new System.Drawing.Point(170, 53);
            this.textBoxDealerMail.Name = "textBoxDealerMail";
            this.textBoxDealerMail.Size = new System.Drawing.Size(209, 20);
            this.textBoxDealerMail.TabIndex = 1;
            // 
            // buttonGotEmail
            // 
            this.buttonGotEmail.Location = new System.Drawing.Point(304, 88);
            this.buttonGotEmail.Name = "buttonGotEmail";
            this.buttonGotEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonGotEmail.TabIndex = 2;
            this.buttonGotEmail.Text = "Готово";
            this.buttonGotEmail.UseVisualStyleBackColor = true;
            this.buttonGotEmail.Click += new System.EventHandler(this.buttonGotEmail_Click);
            // 
            // FormPutDealerEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 123);
            this.Controls.Add(this.buttonGotEmail);
            this.Controls.Add(this.textBoxDealerMail);
            this.Controls.Add(this.label1);
            this.Name = "FormPutDealerEmail";
            this.Text = "FormPutDealerEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDealerMail;
        private System.Windows.Forms.Button buttonGotEmail;
    }
}