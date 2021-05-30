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
    public partial class XeRa : Form
    {
        Xe gx = new Xe();
        public static VideoCapture capture;
        string hinhThuc="";
        int gia;
        string tenDichVu = "";
        string loaiGoi = "";
        public XeRa(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void btnOpenCamera_Click(object sender, EventArgs e)
        {
            openCamera();
        }
        void openCamera()
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

            capture.Start();
        }
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat m = new Mat();
                capture.Retrieve(m);
                picTruocXeCamera.Image = m.ToImage<Bgr, byte>().Bitmap;
                picSauXeCamera.Image = m.ToImage<Bgr, byte>().Bitmap;
                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
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

        private void XeRa_Load(object sender, EventArgs e)
        {
            //DateTime dt = new DateTime(2018,2,3,6,23,55);
            //// dateTimePicker1.Value = dt;
            //dt = dateTimePicker1.Value;
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = gx.timXeDeChoRa(txtTheXe.Text.Trim());
            if (dt.Rows.Count <= 0) {
                MessageBox.Show("The xe chua duoc su dung hoac xe chua xong dich vu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //   $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,x.ngayGioRa,x.phi " +
            txtLoaiXe.Text = dt.Rows[0]["tenLoaiXe"].ToString();
            txtSoXe.Text = dt.Rows[0]["bienSoXe"].ToString();
            dtpGoi.Value = (DateTime)dt.Rows[0]["ngayGioVao"];
            dtpRa.Value = DateTime.Now;
            loaiGoi = dt.Rows[0]["loaiGoi"].ToString();
            gia = (int)dt.Rows[0]["giaTien"];
            tenDichVu = dt.Rows[0]["tenDichVu"].ToString();

            picTruocXe.Image = Ulti.byteArrayToImage((byte[])dt.Rows[0]["anhPhiaTruoc"]);
            picSauXe.Image = Ulti.byteArrayToImage((byte[])dt.Rows[0]["anhPhiaSau"]);
            // string loaiGoi = dt.Rows[0]["loaiGoi"].ToString();
            //   int gia = (int)dt.Rows[0]["giaTien"];
            // string hinhThuc = dt.Rows[0]["tenDichVu"].ToString();
            if (loaiGoi != "")
            {
                //  string hinhThuc = loaiGoi.Split(':')[0].Trim();
                hinhThuc = loaiGoi.Split(':')[0].Trim();
                //  int gia = int.Parse(loaiGoi.Split(':')[1].Trim());

                txtLoaiDV.Text = $"{tenDichVu} - {hinhThuc}";
       
                DateTime vo = dtpGoi.Value;
                DateTime ra = dtpRa.Value;
               
                double gio = (ra - vo).TotalHours;
                double ngay = (ra - vo).TotalDays;

                //if (hinhThuc == "Giờ" && gio < 24)
                //    txtGiaDV.Text = $"{gia* Math.Ceiling(gio)}";
                //else
                //    txtGiaDV.Text = $"{gia}";
                if (hinhThuc == "Giờ" )
                    txtGiaDV.Text = $"{gia * Math.Ceiling(gio)}";

                if (hinhThuc=="Giờ" && gio>24)
                {
                    txtPhat.Text = $"{gia * 8 * 2}";
                }
                else if (hinhThuc == "Ngày" && ngay > 1)
                {
                    txtPhat.Text = $"{gia * 8 * 3}";
                }
                else if (hinhThuc == "Tuần" && ngay > 10 && ngay<30)
                {
                    txtPhat.Text = $"{gia * 8 * 3*2}";
                }
                if(txtPhat.Text!="")
                txtTongTien.Text = (int.Parse(txtGiaDV.Text) + int.Parse(txtPhat.Text)).ToString();
                else
                {
                    txtTongTien.Text = txtGiaDV.Text;
                }
            }
            else
            {
                txtGiaDV.Text = $"{gia}";
                txtTongTien.Text= $"{gia}";
                txtLoaiDV.Text = $"{tenDichVu}";
            }


        }

        private void btnChoRa_Click(object sender, EventArgs e)
        {
            if(gx.updateTheXe(txtTheXe.Text.Trim()))
            {
                MessageBox.Show("Da cho xe ra", "Thong bao", MessageBoxButtons.OK);
            
            }
            else
                MessageBox.Show("Khong Cho Ra Duoc", "Thong bao", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (loaiGoi != "")
            {
                //  string hinhThuc = loaiGoi.Split(':')[0].Trim();
                hinhThuc = loaiGoi.Split(':')[0].Trim();
                //  int gia = int.Parse(loaiGoi.Split(':')[1].Trim());

                txtLoaiDV.Text = $"{tenDichVu} - {hinhThuc}";

                DateTime vo = dtpGoi.Value;
                DateTime ra = dtpRa.Value;

                double gio = (ra - vo).TotalHours;
                double ngay = (ra - vo).TotalDays;

                //if (hinhThuc == "Giờ" && gio < 24)
                //    txtGiaDV.Text = $"{gia* Math.Ceiling(gio)}";
                //else
                //    txtGiaDV.Text = $"{gia}";
                if (hinhThuc == "Giờ")
                    txtGiaDV.Text = $"{gia * Math.Ceiling(gio)}";

                if (hinhThuc == "Giờ" && gio > 24)
                {
                    txtPhat.Text = $"{gia * 8 * 2}";
                }
                else if (hinhThuc == "Ngày" && ngay > 1)
                {
                    txtPhat.Text = $"{gia * 8 * 3}";
                }
                else if (hinhThuc == "Tuần" && ngay > 10 && ngay < 30)
                {
                    txtPhat.Text = $"{gia * 8 * 3 * 2}";
                }
                if (txtPhat.Text != "")
                    txtTongTien.Text = (int.Parse(txtGiaDV.Text) + int.Parse(txtPhat.Text)).ToString();
                else
                {
                    txtTongTien.Text = $"{gia}";
                }
            }
            else
            {
                txtGiaDV.Text = $"{gia}";
                txtTongTien.Text = $"{gia}";
                txtLoaiDV.Text = $"{tenDichVu}";
            }
        }
    }
}
