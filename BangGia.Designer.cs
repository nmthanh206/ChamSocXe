
namespace ChamSocXe
{
    partial class BangGia
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
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXeDap = new System.Windows.Forms.TextBox();
            this.txtXeHoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXeMay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDonVi1 = new System.Windows.Forms.Label();
            this.lblDonVi2 = new System.Windows.Forms.Label();
            this.lblDonVi3 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDichVu
            // 
            this.cbDichVu.FormattingEnabled = true;
            this.cbDichVu.Location = new System.Drawing.Point(179, 29);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(171, 21);
            this.cbDichVu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dịch vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Xe Đạp";
            // 
            // txtXeDap
            // 
            this.txtXeDap.Location = new System.Drawing.Point(179, 99);
            this.txtXeDap.Name = "txtXeDap";
            this.txtXeDap.Size = new System.Drawing.Size(100, 20);
            this.txtXeDap.TabIndex = 3;
            // 
            // txtXeHoi
            // 
            this.txtXeHoi.Location = new System.Drawing.Point(179, 215);
            this.txtXeHoi.Name = "txtXeHoi";
            this.txtXeHoi.Size = new System.Drawing.Size(100, 20);
            this.txtXeHoi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Xe Hơi";
            // 
            // txtXeMay
            // 
            this.txtXeMay.Location = new System.Drawing.Point(179, 157);
            this.txtXeMay.Name = "txtXeMay";
            this.txtXeMay.Size = new System.Drawing.Size(100, 20);
            this.txtXeMay.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Xe Máy:";
            // 
            // lblDonVi1
            // 
            this.lblDonVi1.AutoSize = true;
            this.lblDonVi1.Location = new System.Drawing.Point(285, 106);
            this.lblDonVi1.Name = "lblDonVi1";
            this.lblDonVi1.Size = new System.Drawing.Size(33, 13);
            this.lblDonVi1.TabIndex = 11;
            this.lblDonVi1.Text = "Đồng";
            // 
            // lblDonVi2
            // 
            this.lblDonVi2.AutoSize = true;
            this.lblDonVi2.Location = new System.Drawing.Point(285, 164);
            this.lblDonVi2.Name = "lblDonVi2";
            this.lblDonVi2.Size = new System.Drawing.Size(33, 13);
            this.lblDonVi2.TabIndex = 12;
            this.lblDonVi2.Text = "Đồng";
            // 
            // lblDonVi3
            // 
            this.lblDonVi3.AutoSize = true;
            this.lblDonVi3.Location = new System.Drawing.Point(285, 218);
            this.lblDonVi3.Name = "lblDonVi3";
            this.lblDonVi3.Size = new System.Drawing.Size(33, 13);
            this.lblDonVi3.TabIndex = 13;
            this.lblDonVi3.Text = "Đồng";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(179, 255);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // BangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 290);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblDonVi3);
            this.Controls.Add(this.lblDonVi2);
            this.Controls.Add(this.lblDonVi1);
            this.Controls.Add(this.txtXeMay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtXeHoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXeDap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDichVu);
            this.Name = "BangGia";
            this.Text = "BangGia";
            this.Load += new System.EventHandler(this.BangGia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDichVu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXeDap;
        private System.Windows.Forms.TextBox txtXeHoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXeMay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDonVi1;
        private System.Windows.Forms.Label lblDonVi2;
        private System.Windows.Forms.Label lblDonVi3;
        private System.Windows.Forms.Button btnLuu;
    }
}