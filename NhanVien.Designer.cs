
namespace ChamSocXe
{
    partial class NhanVien
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
            this.lblLoaiNhanVien = new System.Windows.Forms.Label();
            this.lbNhanVien = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblLoaiNhanVien
            // 
            this.lblLoaiNhanVien.AutoSize = true;
            this.lblLoaiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiNhanVien.Location = new System.Drawing.Point(62, 9);
            this.lblLoaiNhanVien.Name = "lblLoaiNhanVien";
            this.lblLoaiNhanVien.Size = new System.Drawing.Size(167, 17);
            this.lblLoaiNhanVien.TabIndex = 1;
            this.lblLoaiNhanVien.Text = "Danh Sách Nhân Viên";
            // 
            // lbNhanVien
            // 
            this.lbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhanVien.FormattingEnabled = true;
            this.lbNhanVien.ItemHeight = 25;
            this.lbNhanVien.Location = new System.Drawing.Point(25, 34);
            this.lbNhanVien.Name = "lbNhanVien";
            this.lbNhanVien.Size = new System.Drawing.Size(302, 304);
            this.lbNhanVien.TabIndex = 2;
            this.lbNhanVien.DoubleClick += new System.EventHandler(this.lbNhanVien_DoubleClick);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 362);
            this.Controls.Add(this.lbNhanVien);
            this.Controls.Add(this.lblLoaiNhanVien);
            this.Name = "NhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLoaiNhanVien;
        private System.Windows.Forms.ListBox lbNhanVien;
    }
}