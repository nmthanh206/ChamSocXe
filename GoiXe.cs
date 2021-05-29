using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocXe
{
    public partial class GoiXe : Form
    {
        public static VideoCapture capture;
        public int MaNV;
        public string tenNV = "";
        Xe gx = new Xe();
        public GoiXe(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void GoiXe_Load(object sender, EventArgs e)
        {
            cbDichVu.DataSource = gx.getDichVu();
            cbDichVu.DisplayMember = "tenDichVu";
            cbDichVu.ValueMember = "maDichVu";
            cbLoaiXe.DataSource = gx.getLoaiXe();
            cbLoaiXe.DisplayMember = "tenLoaiXe";
            cbLoaiXe.ValueMember = "maLoaiXe";
            pictureBox1.Image = Image.FromFile(@"C:\Users\THANH\Desktop\Capture.PNG");
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                capture = new VideoCapture();
                capture.ImageGrabbed += Capture_ImageGrabbed;
            }
            else
            {
                MessageBox.Show("Camera dang mo roi");
                return;
            }
            //  capture = new VideoCapture();
            //  capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                picTruocXe.Image = m.ToImage<Bgr, byte>().Bitmap;
                picSauXe.Image = m.ToImage<Bgr, byte>().Bitmap;
                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (capture != null)
            {
                capture.ImageGrabbed -= Capture_ImageGrabbed;
                capture.Dispose();
                capture = null;
                this.Close();
            }
        }
        public void DisposeCamera()
        {
            if (capture != null)
            {
                capture.ImageGrabbed -= Capture_ImageGrabbed;
                capture.Dispose();
                capture = null;
                this.Close();
            }
        }

        private void btnGiaoViec_Click(object sender, EventArgs e)
        {
            string soThe = txtTheXe.Text.Trim();
            string bienSoXe = txtBienSo.Text.Trim();

            //var imgTruoc = capture.QueryFrame().ToImage<Bgr, byte>();
            //Bitmap bmgTruoc = imgTruoc.Bitmap;
            //Image anhPhiaTruoc = bmgTruoc;

            //var imgSau = capture.QueryFrame().ToImage<Bgr, byte>();
            //Bitmap bmgSau = imgSau.Bitmap;
            //Image anhPhiaSau = bmgSau;
            DateTime ngayGioVao = DateTime.Now;

            string maLoaiXe = cbLoaiXe.SelectedValue.ToString();

            int maDichVu = (int)cbDichVu.SelectedValue;
              if (gx.addXe(soThe, bienSoXe, picTruocXe.Image, picSauXe.Image, ngayGioVao, maLoaiXe, maDichVu, MaNV))
            {
                MessageBox.Show("Them cong viec thanh cong", "Thong bao", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Them cong viec that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {

            NhanVien nv = new NhanVien((int)cbDichVu.SelectedValue, cbDichVu.GetItemText(cbDichVu.SelectedItem), this);
            nv.ShowDialog();
            txtNhanVien.Text = tenNV;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var imgTruoc = capture.QueryFrame().ToImage<Bgr, byte>();
            Bitmap bmgTruoc = imgTruoc.Bitmap;
            Image anhPhiaTruoc = bmgTruoc;
            pictureBox1.Image = anhPhiaTruoc;

        }

    }
}
