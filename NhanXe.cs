using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocXe
{
    public partial class NhanXe : Form
    {
        XeThueMuon xt = new XeThueMuon();

        public NhanXe(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            //--xe
            int maXe = int.Parse(txtMaXe.Text);
            string bienSoXe = txtBienSo.Text;
            Image anhxe = picAnhXe.Image;
            string mauSon = txtMauSon.Text;
            string maLoaiXe = cbLoaiXe.SelectedValue.ToString();
            string nhaHieu = txtNhanHieu.Text;
            string thoiHan = txtThoiHan.Text;

            //-nguoi
            int maNguoiDung = int.Parse(txtmaNguoiChoThue.Text);

            string ten = txtTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = rtxtDiaChi.Text;


            string text = File.ReadAllText(@"C:\Users\THANH\Desktop\New folder\a.txt");


            string tenCty = "CONG TY 1 THÀNH VIÊN CHOMCHOMXYZ";
            string diaChiCty = "Chung cư Trường Thọ";
            text = text.Replace("{tenA}", ten);
            text = text.Replace("{namSinhA}", ngaySinh.ToString("dd-MM-yyyy"));
            text = text.Replace("{diaChiA}", diaChi);
            text = text.Replace("{tenB}", tenCty);
            text = text.Replace("{namSinhB}", "  ");
            text = text.Replace("{diaChiB}", diaChiCty);
            text = text.Replace("{bienSo}", bienSoXe);
            text = text.Replace("{nhanHieu}", nhaHieu);
            string soLoai = "2";
            text = text.Replace("{soLoai}", soLoai);
            text = text.Replace("{loaiXe}", cbLoaiXe.Text);
            text = text.Replace("{mauSon}", mauSon);
            text = text.Replace("{thoiHanThue}", thoiHan);
           
            
            string hopDong = $"{ten}|{ngaySinh.ToString("dd-MM-yyyy")}|{diaChi}|{tenCty}|{"  "}|{diaChiCty}|{bienSoXe}|{nhaHieu}|{soLoai}|{cbLoaiXe.Text}|{mauSon}|{thoiHan}";
            int loai = 0;

            if (xt.addXeVoThue(maXe, bienSoXe, anhxe, mauSon, maLoaiXe, nhaHieu, thoiHan) && xt.addNguoiChoThueHoacThue(maNguoiDung, maXe, ten, ngaySinh, diaChi, hopDong, loai))
            {
                MessageBox.Show("Them thanh cong", "Thong bao", MessageBoxButtons.OK);
                File.WriteAllText(@"C:\Users\THANH\Desktop\New folder\haha.html", text);
                string input = @"C:\Users\THANH\Desktop\New folder\haha.html";
                string output = @"C:\Users\THANH\Desktop\test.docx";
                if (File.Exists(input))
                {
                    SautinSoft.Document.DocumentCore oDocumentCore = SautinSoft.Document.DocumentCore.Load(input);
                    oDocumentCore.Save(output);
                }

                // Open the result for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(output) { UseShellExecute = true });

            }
            else
                MessageBox.Show("Them that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif|*.jpg;*.png;*.gif)";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.picAnhXe.Image = Image.FromFile(opf.FileName);
            }
        }

        private void NhanXe_Load(object sender, EventArgs e)
        {
            cbLoaiXe.DataSource = xt.getLoaiXe();
            cbLoaiXe.DisplayMember = "tenLoaiXe";
            cbLoaiXe.ValueMember = "maLoaiXe";
        }
    }
}
