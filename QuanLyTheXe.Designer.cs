
namespace ChamSocXe
{
    partial class QuanLyTheXe
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
            this.dgvTheXe = new System.Windows.Forms.DataGridView();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtThe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTheXe
            // 
            this.dgvTheXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheXe.Location = new System.Drawing.Point(18, 12);
            this.dgvTheXe.Name = "dgvTheXe";
            this.dgvTheXe.Size = new System.Drawing.Size(252, 337);
            this.dgvTheXe.TabIndex = 0;
            this.dgvTheXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTheXe_CellClick);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(114, 411);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtThe
            // 
            this.txtThe.Location = new System.Drawing.Point(89, 364);
            this.txtThe.Name = "txtThe";
            this.txtThe.Size = new System.Drawing.Size(100, 20);
            this.txtThe.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập Thẻ";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(19, 411);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(219, 411);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // QuanLyTheXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 446);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThe);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvTheXe);
            this.Name = "QuanLyTheXe";
            this.Text = "QuanLyTheXe";
            this.Load += new System.EventHandler(this.QuanLyTheXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTheXe;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtThe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
    }
}