using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {

        }
    }
}
