
namespace ChamSocXe
{
    partial class DanhSachHopDong
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
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Location = new System.Drawing.Point(234, 49);
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.Size = new System.Drawing.Size(525, 352);
            this.dgvHopDong.TabIndex = 0;
            // 
            // DanhSachHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHopDong);
            this.Name = "DanhSachHopDong";
            this.Text = "DanhSachHopDong";
            this.Load += new System.EventHandler(this.DanhSachHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHopDong;
    }
}