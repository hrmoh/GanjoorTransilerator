﻿namespace GanjoorTransilerator
{
    partial class MainForm
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.btnSelectDbFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.prgrss = new System.Windows.Forms.ProgressBar();
            this.lblPoet = new System.Windows.Forms.Label();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblPoem = new System.Windows.Forms.Label();
            this.lblVerse = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Controls.Add(this.btnSelectDbFile);
            this.grp.Controls.Add(this.txtFilePath);
            this.grp.Location = new System.Drawing.Point(12, 12);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(759, 79);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            this.grp.Text = "مسیر پایگاه داده‌ها:";
            // 
            // btnSelectDbFile
            // 
            this.btnSelectDbFile.Location = new System.Drawing.Point(14, 31);
            this.btnSelectDbFile.Name = "btnSelectDbFile";
            this.btnSelectDbFile.Size = new System.Drawing.Size(31, 23);
            this.btnSelectDbFile.TabIndex = 1;
            this.btnSelectDbFile.Text = "...";
            this.btnSelectDbFile.UseVisualStyleBackColor = true;
            this.btnSelectDbFile.Click += new System.EventHandler(this.btnSelectDbFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(51, 31);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFilePath.Size = new System.Drawing.Size(690, 21);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 97);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(759, 23);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "شروع تبدیل";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // prgrss
            // 
            this.prgrss.Location = new System.Drawing.Point(12, 229);
            this.prgrss.Name = "prgrss";
            this.prgrss.Size = new System.Drawing.Size(759, 23);
            this.prgrss.TabIndex = 2;
            // 
            // lblPoet
            // 
            this.lblPoet.AutoSize = true;
            this.lblPoet.Location = new System.Drawing.Point(12, 123);
            this.lblPoet.Name = "lblPoet";
            this.lblPoet.Size = new System.Drawing.Size(33, 13);
            this.lblPoet.TabIndex = 3;
            this.lblPoet.Text = "شاعر";
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(12, 145);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(31, 13);
            this.lblCat.TabIndex = 4;
            this.lblCat.Text = "بخش";
            // 
            // lblPoem
            // 
            this.lblPoem.AutoSize = true;
            this.lblPoem.Location = new System.Drawing.Point(14, 168);
            this.lblPoem.Name = "lblPoem";
            this.lblPoem.Size = new System.Drawing.Size(29, 13);
            this.lblPoem.TabIndex = 5;
            this.lblPoem.Text = "شعر";
            // 
            // lblVerse
            // 
            this.lblVerse.AutoSize = true;
            this.lblVerse.Location = new System.Drawing.Point(15, 192);
            this.lblVerse.Name = "lblVerse";
            this.lblVerse.Size = new System.Drawing.Size(22, 13);
            this.lblVerse.TabIndex = 6;
            this.lblVerse.Text = "خط";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 283);
            this.Controls.Add(this.lblVerse);
            this.Controls.Add(this.lblPoem);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.lblPoet);
            this.Controls.Add(this.prgrss);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "تبدیل‌کنندهٔ متن گنجور به تاجیکی";
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Button btnSelectDbFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar prgrss;
        private System.Windows.Forms.Label lblPoet;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblPoem;
        private System.Windows.Forms.Label lblVerse;
    }
}

