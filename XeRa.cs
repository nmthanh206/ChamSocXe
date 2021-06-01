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
        string hinhThuc = "";
        int gia;
        string tenDichVu = "";
        string loaiGoi = "";
        int idXe;
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
            button1.Visible = false;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dt = gx.timXeDeChoRa(txtTheXe.Text.Trim());

            int layCuoi = dt.Rows.Count - 1;
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("The xe chua duoc su dung hoac xe chua xong dich vu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //   $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,x.ngayGioRa,x.phi " +
            idXe = (int)dt.Rows[0]["id"];
            txtLoaiXe.Text = dt.Rows[0]["tenLoaiXe"].ToString();
            txtSoXe.Text = dt.Rows[0]["bienSoXe"].ToString();
            dtpGoi.Value = (DateTime)dt.Rows[0]["ngayGioVao"];
            dtpRa.Value = DateTime.Now;
            loaiGoi = dt.Rows[0]["loaiGoi"].ToString();
            gia = (int)dt.Rows[0]["giaTien"];
            tenDichVu = dt.Rows[0]["tenDichVu"].ToString();

            picTruocXe.Image = Ulti.byteArrayToImage((byte[])dt.Rows[0]["anhPhiaTruoc"]);
            picSauXe.Image = Ulti.byteArrayToImage((byte[])dt.Rows[0]["anhPhiaSau"]);
            //-- clear tien phat moi lan tim
            txtPhat.Text = "";
            //-- clear tong thoi gian phat moi lan tim
            txtTongThoiGian.Text = "";
            if (loaiGoi.Contains(":"))
            {
                hinhThuc = loaiGoi.Split(':')[0].Trim();


                txtLoaiDV.Text = $"{tenDichVu} - {hinhThuc}";

                DateTime vo = dtpGoi.Value;
                DateTime ra = dtpRa.Value;

                double gio = (ra - vo).TotalHours;
                double ngay = (ra - vo).TotalDays;

                int giaGio = gia;
                int giaNgay = gia * 8;
                int giaTuan = giaNgay * 3;
                int giaThang = giaTuan * 2;
                if (hinhThuc == "Giờ")
                {
                    int tien = ((int)Math.Ceiling(gia * Math.Round(gio, 2)))< gia?gia: ((int)Math.Ceiling(gia * Math.Round(gio, 2)));
                    txtGiaDV.Text = $"{tien}";
                    if (gio > 24)
                        txtPhat.Text = $"{giaNgay * 2}";
                }
                if (hinhThuc == "Ngày")
                {
                    txtGiaDV.Text = $"{gia * 8}";
                    if (ngay > 1)
                        txtPhat.Text = $"{giaTuan * 1}";
                }
                if (hinhThuc == "Tuần")
                {
                    txtGiaDV.Text = $"{gia}";
                    if (ngay > 10 && ngay < 30)
                        txtPhat.Text = $"{giaThang * 1}";
                }

                if (hinhThuc == "Tháng")
                {
                    txtGiaDV.Text = $"{gia}";
                    if (ngay > 30)
                    {
                        int soGioQuaHan = (int)Math.Round(gio / 24 * 30);
                        txtPhat.Text = $"{giaThang + giaTuan + (gia * soGioQuaHan)}";

                    }
                }
                //----------Tong Thoi Gian
                // txtTongThoiGian.Text = ra.Subtract(vo).ToString();
                string[] kq = (ra - vo).ToString().Split('.');
                string soNgay = "";
                string thoiGian = "";
                string soGio = "";
                string soPhut = "";
                //     string soGiay = "";
                //if (kq[0].Length > 2)
                //{
                //    thoiGian = kq[0];

                //}
                //else
                //{
                //    soNgay = $"{kq[0]} Ngày";
                //    thoiGian = kq[1];
                //}
                if (ngay>1)
                {
                    thoiGian = kq[0];
                    soNgay = $"{kq[0]} Ngày";
                    thoiGian = kq[1];
                }
                else
                {
                    thoiGian = kq[0];
                    //if (gio < 1)
                    //{
                    //    thoiGian = kq[0];
                    //    soNgay = $"{kq[0]} Ngày";
                    //    thoiGian = kq[1];
                    //}
                }


                soGio = $"{thoiGian.Substring(0, 2)} Giờ";
                soPhut = $"{thoiGian.Substring(3, 2)} Phút";
                //  soGiay = $"{thoiGian.Substring(6, 2)} Giây";

                txtTongThoiGian.Text = $"{soNgay} {soGio}{soPhut}";


            }
            else
            {
                txtLoaiDV.Text = $"{tenDichVu}";
                txtGiaDV.Text = txtTongTien.Text = $"{gia}";

            }

            //---Tinh Tong Tien
            if (txtPhat.Text != "")
                txtTongTien.Text = (int.Parse(txtGiaDV.Text) + int.Parse(txtPhat.Text)).ToString();
            else
            {
                txtTongTien.Text = txtGiaDV.Text;
            }




        }

        private void btnChoRa_Click(object sender, EventArgs e)
        {
            if (txtLoaiXe.Text == "")
            {
                MessageBox.Show("Co xe dau ma ra", "Thong bao", MessageBoxButtons.OK);
                return;
            }
            if (gx.updateTheXe(txtTheXe.Text.Trim()) && gx.updateXe(idXe, txtTongTien.Text.Trim(), dtpRa.Value))
            {
                    MessageBox.Show("Da cho xe ra", "Thong bao", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Khong Cho Ra Duoc", "Thong bao", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime vo = dtpGoi.Value;
            DateTime ra = dtpRa.Value;

            // txtTongThoiGian.Text = ra.Subtract(vo).ToString();
            string[] kq = (ra - vo).ToString().Split('.');
            string soNgay = "";
            string thoiGian = "";
            string soGio = "";
            string soPhut = "";
            //     string soGiay = "";
            if (kq[0].Length > 2)
            {
                thoiGian = kq[0];

            }
            else
            {
                soNgay = $"{kq[0]} Ngày";
                thoiGian = kq[1];
            }


            soGio = $"{thoiGian.Substring(0, 2)} Giờ";
            soPhut = $"{thoiGian.Substring(3, 2)} Phút";
            //  soGiay = $"{thoiGian.Substring(6, 2)} Giây";

            txtTongThoiGian.Text = $"{soNgay}{soGio}{soPhut}";
        }
    }
}
