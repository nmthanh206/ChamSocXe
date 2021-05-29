
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.dgvDichVuXe = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuXe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(50, 68);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 0;
            this.btnShowAll.Text = "Tất Cả Xe";
            this.btnShowAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm Theo Bảng Số Xe";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(312, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // cbDichVu
            // 
            this.cbDichVu.FormattingEnabled = true;
            this.cbDichVu.Location = new System.Drawing.Point(604, 73);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(139, 21);
            this.cbDichVu.TabIndex = 3;
            // 
            // dgvDichVuXe
            // 
            this.dgvDichVuXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuXe.Location = new System.Drawing.Point(50, 129);
            this.dgvDichVuXe.Name = "dgvDichVuXe";
            this.dgvDichVuXe.Size = new System.Drawing.Size(705, 286);
            this.dgvDichVuXe.TabIndex = 4;
            // 
            // DanhSachXeSuDungDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDichVuXe);
            this.Controls.Add(this.cbDichVu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbDichVu;
        private System.Windows.Forms.DataGridView dgvDichVuXe;
    }
}