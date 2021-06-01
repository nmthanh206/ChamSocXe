
namespace ChamSocXe
{
    partial class DanhSachXeSuDungDichVu
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
            this.btnShowAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimSoXe = new System.Windows.Forms.TextBox();
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.dgvDichVuXe = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnTimSoXe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuXe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(23, 14);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 0;
            this.btnShowAll.Text = "Tất Cả Xe";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm Theo Bảng Số Xe";
            // 
            // txtTimSoXe
            // 
            this.txtTimSoXe.Location = new System.Drawing.Point(438, 17);
            this.txtTimSoXe.Name = "txtTimSoXe";
            this.txtTimSoXe.Size = new System.Drawing.Size(100, 20);
            this.txtTimSoXe.TabIndex = 2;
            // 
            // cbDichVu
            // 
            this.cbDichVu.FormattingEnabled = true;
            this.cbDichVu.Location = new System.Drawing.Point(985, 12);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(139, 21);
            this.cbDichVu.TabIndex = 3;
            // 
            // dgvDichVuXe
            // 
            this.dgvDichVuXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuXe.Location = new System.Drawing.Point(23, 53);
            this.dgvDichVuXe.Name = "dgvDichVuXe";
            this.dgvDichVuXe.Size = new System.Drawing.Size(1186, 494);
            this.dgvDichVuXe.TabIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(540, 553);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnTimSoXe
            // 
            this.btnTimSoXe.Location = new System.Drawing.Point(572, 13);
            this.btnTimSoXe.Name = "btnTimSoXe";
            this.btnTimSoXe.Size = new System.Drawing.Size(75, 23);
            this.btnTimSoXe.TabIndex = 5;
            this.btnTimSoXe.Text = "Tìm";
            this.btnTimSoXe.UseVisualStyleBackColor = true;
            this.btnTimSoXe.Click += new System.EventHandler(this.btnTimSoXe_Click);
            // 
            // DanhSachXeSuDungDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1245, 588);
            this.Controls.Add(this.btnTimSoXe);
            this.Controls.Add(this.dgvDichVuXe);
            this.Controls.Add(this.cbDichVu);
            this.Controls.Add(this.txtTimSoXe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnShowAll);
            this.Name = "DanhSachXeSuDungDichVu";
            this.Text = "DanhSachXeSuDungDichVu";
            this.Load += new System.EventHandler(this.DanhSachXeSuDungDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimSoXe;
        private System.Windows.Forms.ComboBox cbDichVu;
        private System.Windows.Forms.DataGridView dgvDichVuXe;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnTimSoXe;
    }
}