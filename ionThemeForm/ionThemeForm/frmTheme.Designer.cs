namespace ionThemeForm
{
    partial class frmTheme
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ionForm3 = new ionForm();
            this.ionClose2 = new ionClose();
            this.ionButton2 = new ionButton();
            this.ionTextBox1 = new ionTextBox();
            this.ionButton1 = new ionButton();
            this.ionForm3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ionForm3
            // 
            this.ionForm3.Controls.Add(this.ionClose2);
            this.ionForm3.Controls.Add(this.ionButton2);
            this.ionForm3.Controls.Add(this.ionTextBox1);
            this.ionForm3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ionForm3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.ionForm3.Location = new System.Drawing.Point(0, 0);
            this.ionForm3.Name = "ionForm3";
            this.ionForm3.Padding = new System.Windows.Forms.Padding(1, 32, 1, 1);
            this.ionForm3.Size = new System.Drawing.Size(284, 187);
            this.ionForm3.TabIndex = 0;
            this.ionForm3.Text = "ionForm3";
            // 
            // ionClose2
            // 
            this.ionClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ionClose2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.ionClose2.Font = new System.Drawing.Font("Marlett", 12F);
            this.ionClose2.Location = new System.Drawing.Point(259, 0);
            this.ionClose2.Name = "ionClose2";
            this.ionClose2.Size = new System.Drawing.Size(25, 25);
            this.ionClose2.TabIndex = 2;
            this.ionClose2.Text = "ionClose2";
            // 
            // ionButton2
            // 
            this.ionButton2.Location = new System.Drawing.Point(40, 115);
            this.ionButton2.Name = "ionButton2";
            this.ionButton2.Size = new System.Drawing.Size(210, 35);
            this.ionButton2.TabIndex = 1;
            this.ionButton2.Text = "ionButton2";
            // 
            // ionTextBox1
            // 
            this.ionTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ionTextBox1.Location = new System.Drawing.Point(40, 74);
            this.ionTextBox1.MaxLength = 0;
            this.ionTextBox1.Multiline = false;
            this.ionTextBox1.Name = "ionTextBox1";
            this.ionTextBox1.ReadOnly = false;
            this.ionTextBox1.Size = new System.Drawing.Size(210, 35);
            this.ionTextBox1.TabIndex = 0;
            this.ionTextBox1.Text = "ionTextBox1";
            this.ionTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.ionTextBox1.UseSystemPasswordChar = false;
            // 
            // ionButton1
            // 
            this.ionButton1.Location = new System.Drawing.Point(38, 177);
            this.ionButton1.Name = "ionButton1";
            this.ionButton1.Size = new System.Drawing.Size(210, 35);
            this.ionButton1.TabIndex = 1;
            this.ionButton1.Text = "ionButton1";
            this.ionButton1.Click += new System.EventHandler(this.ionButton1_Click);
            // 
            // frmTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 187);
            this.Controls.Add(this.ionForm3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTheme";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.ionForm3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ionForm ionForm3;
        private ionClose ionClose1;
        private ionButton ionButton1;
        private ionButton ionButton2;
        private ionTextBox ionTextBox1;
        private ionClose ionClose2;
    }
}

