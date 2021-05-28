
namespace ChamSocXe
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tHỢToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.cHUYÊNMÔNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýChuyênMônToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tHỢToolStripMenuItem,
            this.cHUYÊNMÔNToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1230, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tHỢToolStripMenuItem
            // 
            this.tHỢToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýThợToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.tHỢToolStripMenuItem.Name = "tHỢToolStripMenuItem";
            this.tHỢToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.tHỢToolStripMenuItem.Text = "THỢ";
            // 
            // quảnLýThợToolStripMenuItem
            // 
            this.quảnLýThợToolStripMenuItem.Name = "quảnLýThợToolStripMenuItem";
            this.quảnLýThợToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.quảnLýThợToolStripMenuItem.Text = "Quản Lý Thợ";
            this.quảnLýThợToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThợToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.closeToolStripMenuItem.Text = "close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnContainer
            // 
            this.pnContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 24);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(1230, 529);
            this.pnContainer.TabIndex = 1;
            // 
            // cHUYÊNMÔNToolStripMenuItem
            // 
            this.cHUYÊNMÔNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýChuyênMônToolStripMenuItem});
            this.cHUYÊNMÔNToolStripMenuItem.Name = "cHUYÊNMÔNToolStripMenuItem";
            this.cHUYÊNMÔNToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.cHUYÊNMÔNToolStripMenuItem.Text = "CHUYÊN MÔN";
            // 
            // quảnLýChuyênMônToolStripMenuItem
            // 
            this.quảnLýChuyênMônToolStripMenuItem.Name = "quảnLýChuyênMônToolStripMenuItem";
            this.quảnLýChuyênMônToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.quảnLýChuyênMônToolStripMenuItem.Text = "Quản Lý Chuyên Môn";
            this.quảnLýChuyênMônToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChuyênMônToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 553);
            this.Controls.Add(this.pnContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tHỢToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýThợToolStripMenuItem;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHUYÊNMÔNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýChuyênMônToolStripMenuItem;
    }
}