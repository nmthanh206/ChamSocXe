﻿
namespace ChamSocXe
{
    partial class DoanhThu
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
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpLoc = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.radCaHai = new System.Windows.Forms.RadioButton();
            this.radNgay = new System.Windows.Forms.RadioButton();
            this.radDichVu = new System.Windows.Forms.RadioButton();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(27, 74);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.Size = new System.Drawing.Size(889, 374);
            this.dgvDoanhThu.TabIndex = 0;
            // 
            // cbDichVu
            // 
            this.cbDichVu.FormattingEnabled = true;
            this.cbDichVu.Location = new System.Drawing.Point(777, 23);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(139, 21);
            this.cbDichVu.TabIndex = 4;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(27, 21);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "Tất Cả Xe";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn Ngày";
            // 
            // dtpLoc
            // 
            this.dtpLoc.CustomFormat = "MM-dd-yyyy  ";
            this.dtpLoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLoc.Location = new System.Drawing.Point(321, 21);
            this.dtpLoc.Name = "dtpLoc";
            this.dtpLoc.Size = new System.Drawing.Size(96, 20);
            this.dtpLoc.TabIndex = 21;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(447, 21);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // radCaHai
            // 
            this.radCaHai.AutoSize = true;
            this.radCaHai.Location = new System.Drawing.Point(549, 27);
            this.radCaHai.Name = "radCaHai";
            this.radCaHai.Size = new System.Drawing.Size(57, 17);
            this.radCaHai.TabIndex = 22;
            this.radCaHai.TabStop = true;
            this.radCaHai.Text = "Cả Hai";
            this.radCaHai.UseVisualStyleBackColor = true;
            // 
            // radNgay
            // 
            this.radNgay.AutoSize = true;
            this.radNgay.Location = new System.Drawing.Point(621, 27);
            this.radNgay.Name = "radNgay";
            this.radNgay.Size = new System.Drawing.Size(50, 17);
            this.radNgay.TabIndex = 22;
            this.radNgay.TabStop = true;
            this.radNgay.Text = "Ngày";
            this.radNgay.UseVisualStyleBackColor = true;
            // 
            // radDichVu
            // 
            this.radDichVu.AutoSize = true;
            this.radDichVu.Location = new System.Drawing.Point(677, 27);
            this.radDichVu.Name = "radDichVu";
            this.radDichVu.Size = new System.Drawing.Size(63, 17);
            this.radDichVu.TabIndex = 22;
            this.radDichVu.TabStop = true;
            this.radDichVu.Text = "Dịch Vụ";
            this.radDichVu.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(370, 476);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(125, 30);
            this.btnIn.TabIndex = 23;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 537);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.radDichVu);
            this.Controls.Add(this.radNgay);
            this.Controls.Add(this.radCaHai);
            this.Controls.Add(this.dtpLoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.cbDichVu);
            this.Controls.Add(this.dgvDoanhThu);
            this.Name = "DoanhThu";
            this.Text = "DoanhThu";
            this.Load += new System.EventHandler(this.DoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.ComboBox cbDichVu;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.RadioButton radCaHai;
        private System.Windows.Forms.RadioButton radNgay;
        private System.Windows.Forms.RadioButton radDichVu;
        private System.Windows.Forms.Button btnIn;
    }
}