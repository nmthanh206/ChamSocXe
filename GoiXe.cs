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
        List<int> giaTienTheoXe;
        List<int> giaTienTheoXeSuaXe;
        List<int> giaTienRuaXe;
        private void GoiXe_Load(object sender, EventArgs e)
        {
            cbDichVu.DataSource = gx.getDichVu();
            cbDichVu.DisplayMember = "tenDichVu";
            cbDichVu.ValueMember = "maDichVu";

        

            cbLoaiXe.DataSource = gx.getLoaiXe();
            cbLoaiXe.DisplayMember = "tenLoaiXe";
            cbLoaiXe.ValueMember = "maLoaiXe";

            cbDichVu.SelectedValueChanged += CbDichVu_SelectedValueChanged;
            cbLoaiXe.SelectedValueChanged += CbLoaiXe_SelectedValueChanged;

            cbLoaiGoi.Enabled = false;
            giaTienTheoXe = gx.getGiaTheoGioCacLoaiXe();
            giaTienTheoXeSuaXe = gx.getGiaSuaXe();
            giaTienRuaXe = gx.getGiaRuaXe();
            CbDichVu_SelectedValueChanged(sender, e);
            CbLoaiXe_SelectedValueChanged(sender, e);
           //    openCamera();


        }

        private void CbLoaiXe_SelectedValueChanged(object sender, EventArgs e)
        {
            updateGiaDichVu((int)cbDichVu.SelectedValue);
        
        }
        void updateGiaDichVu(int maDichVu)
        {
            if (maDichVu == 1)
            {
                lblLoai.Text = "Loại Gởi";
                cbLoaiGoi.Items.Clear();
                int gia;
                if (cbLoaiXe.Text == "Xe Đạp")
                    gia = giaTienTheoXe[0];
                else if (cbLoaiXe.Text == "Xe Máy")
                    gia = giaTienTheoXe[1];
                else
                    gia = giaTienTheoXe[2];
                cbLoaiGoi.Items.Add($"Giờ : {gia}");
                cbLoaiGoi.Items.Add($"Ngày : {8 * gia}");
                cbLoaiGoi.Items.Add($"Tuần : {8 * gia * 3}");
                cbLoaiGoi.Items.Add($"Tháng : {8 * gia * 3 * 2}");
            }
            else if (maDichVu == 2)
            {
                lblLoai.Text = "Giá";
                cbLoaiGoi.Items.Clear();

                int gia;
                if (cbLoaiXe.Text == "Xe Đạp")
                    gia = giaTienTheoXeSuaXe[0];
                else if (cbLoaiXe.Text == "Xe Máy")
                    gia = giaTienTheoXeSuaXe[1];
                else
                    gia = giaTienTheoXeSuaXe[2];
                cbLoaiGoi.Items.Add($"{gia}");
            }
            else if (maDichVu == 3)
            {
                lblLoai.Text = "Giá";
                cbLoaiGoi.Items.Clear();
                int gia;
                if (cbLoaiXe.Text == "Xe Đạp")
                    gia = giaTienRuaXe[0];
                else if (cbLoaiXe.Text == "Xe Máy")
                    gia = giaTienRuaXe[1];
                else
                    gia = giaTienRuaXe[2];
                cbLoaiGoi.Items.Add($"{gia}");
            }
            cbLoaiGoi.SelectedIndex = 0;
        }

        private void CbDichVu_SelectedValueChanged(object sender, EventArgs e)
        {
           
            if ((int)cbDichVu.SelectedValue == 1)
            {

                cbLoaiGoi.Enabled = true;
           //     CbLoaiXe_SelectedValueChanged(sender, e);
            }
            else
            {
           //     CbLoaiXe_SelectedValueChanged(sender, e);
                cbLoaiGoi.Enabled = false;
                
            }
            updateGiaDichVu((int)cbDichVu.SelectedValue);

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

            DateTime ngayGioVao = DateTime.Now;

            string maLoaiXe = cbLoaiXe.SelectedValue.ToString();

            int maDichVu = (int)cbDichVu.SelectedValue;
            //      string loaiGoi = cbLoaiGoi.Text.Split(':')[0].Trim();
            string loaiGoi = "";
            if ((int)cbDichVu.SelectedValue==1)
                loaiGoi = cbLoaiGoi.Text.Trim();
            int phi=0;
            if (lblLoai.Text=="Giá")
                phi = int.Parse(cbLoaiGoi.Text.Trim());
            if (gx.addXe(soThe, bienSoXe, picTruocXe.Image, picSauXe.Image, ngayGioVao, maLoaiXe, maDichVu, MaNV, loaiGoi,phi))
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



    }
}
