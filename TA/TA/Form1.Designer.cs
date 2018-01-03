namespace TA
{
    partial class win1
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
            this.tbDate = new System.Windows.Forms.TextBox();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.txKey = new System.Windows.Forms.TextBox();
            this.btEncrypt = new System.Windows.Forms.Button();
            this.lbKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDate
            // 
            this.tbDate.Enabled = false;
            this.tbDate.Location = new System.Drawing.Point(12, 491);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(188, 20);
            this.tbDate.TabIndex = 0;
            this.tbDate.TextChanged += new System.EventHandler(this.tbDate_TextChanged);
            // 
            // pbLoad
            // 
            this.pbLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbLoad.Location = new System.Drawing.Point(12, 26);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(480, 459);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 1;
            this.pbLoad.TabStop = false;
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(391, 488);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(101, 23);
            this.btOpen.TabIndex = 3;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // pbShow
            // 
            this.pbShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbShow.Location = new System.Drawing.Point(499, 26);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(480, 459);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShow.TabIndex = 4;
            this.pbShow.TabStop = false;
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(878, 488);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(101, 23);
            this.btDecrypt.TabIndex = 5;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // txKey
            // 
            this.txKey.Location = new System.Drawing.Point(985, 43);
            this.txKey.Name = "txKey";
            this.txKey.Size = new System.Drawing.Size(173, 20);
            this.txKey.TabIndex = 6;
            this.txKey.Tag = "";
            this.txKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btEncrypt
            // 
            this.btEncrypt.Location = new System.Drawing.Point(763, 489);
            this.btEncrypt.Name = "btEncrypt";
            this.btEncrypt.Size = new System.Drawing.Size(109, 23);
            this.btEncrypt.TabIndex = 7;
            this.btEncrypt.Text = "Encrypt";
            this.btEncrypt.UseVisualStyleBackColor = true;
            this.btEncrypt.Click += new System.EventHandler(this.btEncrypt_Click);
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(985, 26);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(25, 13);
            this.lbKey.TabIndex = 8;
            this.lbKey.Text = "Key";
            // 
            // win1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1165, 513);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.btEncrypt);
            this.Controls.Add(this.txKey);
            this.Controls.Add(this.btDecrypt);
            this.Controls.Add(this.pbShow);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.tbDate);
            this.Name = "win1";
            this.Text = "Tugas Akhirku";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.TextBox txKey;
        private System.Windows.Forms.Button btEncrypt;
        private System.Windows.Forms.Label lbKey;
    }
}

