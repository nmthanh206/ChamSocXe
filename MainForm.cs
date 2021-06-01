using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocXe
{
    public partial class MainForm : Form
    {
        GoiXe gxf;
        public MainForm()
        {
            InitializeComponent();
        }
        Form children;

        private void quảnLýThợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            QuanLyTho qltf = new QuanLyTho(this);
            openForm(qltf);
    
        }
        void openForm(Form form)
        {
           
            children = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.AutoScroll = true;
            pnContainer.Controls.Add(form);
            form.Show();

        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bool a=children.Visible;
            //this.panel1.Controls.Remove(children);
            //FormCollection fc = Application.OpenForms;
            //foreach (Form frm in fc)
            //{
            //    //iterate through
            //    if (frm.Visible && frm.Name != "MainForm")
            //    {
            //        this.panel1.Controls.Remove(frm);
            //        //   frm.Close();
            //    }
            //}
      
         //   pnContainer.Controls.Clear();
            foreach (Control c in pnContainer.Controls)
                c.Dispose();
        }
        void CloseAllForm()
        {
            if (GoiXe.capture != null)
            {
                gxf.DisposeCamera();
            }
            foreach (Control c in pnContainer.Controls)
                c.Dispose();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýChuyênMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            ChuyenMon cmf = new ChuyenMon(this);
            openForm(cmf);
        }

        private void gởiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            gxf = new GoiXe(this);
            openForm(gxf);
        }

        private void danhSáchXeSửDụngDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            XeRa dsxdv = new XeRa(this);
            openForm(dsxdv);
        }

        private void xeRaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            DanhSachXeSuDungDichVu dsxdv = new DanhSachXeSuDungDichVu(this);
            openForm(dsxdv);
        }

        private void quảnLýBảngGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            BangGia bgf = new BangGia(this);
            openForm(bgf);
        }

        private void quảnLýBãiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChoTrong ct = new ChoTrong();
            ct.ShowDialog();

        }

        private void xemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            DoanhThu dtf = new DoanhThu(this);
            openForm(dtf);
        }

        private void choThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhậnXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllForm();
            NhanXe nxf = new NhanXe(this);
            openForm(nxf);
        }
    }
}
