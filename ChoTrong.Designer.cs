
namespace ChamSocXe
{
    partial class ChoTrong
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
            this.dgvChoTrong = new System.Windows.Forms.DataGridView();
            this.lblXe = new System.Windows.Forms.Label();
            this.txtToiDa = new System.Windows.Forms.TextBox();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoTrong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChoTrong
            // 
            this.dgvChoTrong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoTrong.Location = new System.Drawing.Point(164, 17);
            this.dgvChoTrong.Name = "dgvChoTrong";
            this.dgvChoTrong.Size = new System.Drawing.Size(372, 117);
            this.dgvChoTrong.TabIndex = 0;
            this.dgvChoTrong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChoTrong_CellClick);
            // 
            // lblXe
            // 
            this.lblXe.AutoSize = true;
            this.lblXe.Location = new System.Drawing.Point(66, 17);
            this.lblXe.Name = "lblXe";
            this.lblXe.Size = new System.Drawing.Size(42, 13);
            this.lblXe.TabIndex = 1;
            this.lblXe.Text = "Xe đạp";
            // 
            // txtToiDa
            // 
            this.txtToiDa.Location = new System.Drawing.Point(13, 47);
            this.txtToiDa.Name = "txtToiDa";
            this.txtToiDa.Size = new System.Drawing.Size(50, 20);
            this.txtToiDa.TabIndex = 2;
            // 
            // txtCon
            // 
            this.txtCon.Location = new System.Drawing.Point(98, 47);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(50, 20);
            this.txtCon.TabIndex = 6;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(52, 96);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 7;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // ChoTrong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 146);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtCon);
            this.Controls.Add(this.txtToiDa);
            this.Controls.Add(this.lblXe);
            this.Controls.Add(this.dgvChoTrong);
            this.Name = "ChoTrong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChoTrong";
            this.Load += new System.EventHandler(this.ChoTrong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoTrong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChoTrong;
        private System.Windows.Forms.Label lblXe;
        private System.Windows.Forms.TextBox txtToiDa;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.Button btnCapNhat;
    }
}