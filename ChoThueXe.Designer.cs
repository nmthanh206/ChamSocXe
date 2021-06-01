
namespace ChamSocXe
{
    partial class ChoThueXe
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
            this.dgvXeChoThue = new System.Windows.Forms.DataGridView();
            this.btnThue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXeChoThue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvXeChoThue
            // 
            this.dgvXeChoThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXeChoThue.Location = new System.Drawing.Point(12, 36);
            this.dgvXeChoThue.Name = "dgvXeChoThue";
            this.dgvXeChoThue.Size = new System.Drawing.Size(1039, 443);
            this.dgvXeChoThue.TabIndex = 0;
            this.dgvXeChoThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXeChoThue_CellClick);
            this.dgvXeChoThue.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // btnThue
            // 
            this.btnThue.Location = new System.Drawing.Point(484, 495);
            this.btnThue.Name = "btnThue";
            this.btnThue.Size = new System.Drawing.Size(75, 23);
            this.btnThue.TabIndex = 1;
            this.btnThue.Text = "Thuê";
            this.btnThue.UseVisualStyleBackColor = true;
            this.btnThue.Click += new System.EventHandler(this.btnThue_Click);
            // 
            // ChoThueXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 530);
            this.Controls.Add(this.btnThue);
            this.Controls.Add(this.dgvXeChoThue);
            this.Name = "ChoThueXe";
            this.Text = "ChoThueXe";
            this.Load += new System.EventHandler(this.ChoThueXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXeChoThue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvXeChoThue;
        private System.Windows.Forms.Button btnThue;
    }
}