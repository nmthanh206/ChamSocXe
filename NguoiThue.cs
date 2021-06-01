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
    public partial class NguoiThue : Form
    {
        string maLoaiXe2;
        XeThueMuon xt = new XeThueMuon();
        public NguoiThue(string [] data,Image anhXe)
        {
            InitializeComponent();
            picAnhXe.Image = anhXe;
       //     string[] data = { maXe, bienSoXe, mauSon, maLoaiXe, tenLoaiXe, nhaHieu, thoiHan };
            txtMaXe.Text = data[0];
            txtBienSo.Text = data[1];
            txtMauSon.Text = data[2];
            txtNhanHieu.Text = data[5];
            maLoaiXe2 = data[3];
            txtTenLoaiXe.Text = data[4];
            numThoiHan.Value = int.Parse(data[6]);
            numThoiHan.Maximum = int.Parse(data[6]);
            numThoiHan.Minimum = 1;
        }

        private void NguoiThue_Load(object sender, EventArgs e)
        {

        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            //--xe
            int maXe = int.Parse(txtMaXe.Text);
            string bienSoXe = txtBienSo.Text;
            string mauSon = txtMauSon.Text;
            string nhaHieu = txtNhanHieu.Text;
            string thoiHan = numThoiHan.Value.ToString();
            int tien = int.Parse(txtTien.Text);
            //-nguoi
            int maNguoiDung = int.Parse(txtmaNguoiChoThue.Text);

            string ten = txtTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string diaChi = rtxtDiaChi.Text;


            string text = File.ReadAllText(Ulti.filepath);


            string tenCty = "CONG TY 1 THÀNH VIÊN CHOMCHOMXYZ";
            string diaChiCty = "Chung cư Trường Thọ";
            text = text.Replace("{tenB}", ten);
            text = text.Replace("{namSinhB}", ngaySinh.ToString("dd-MM-yyyy"));
            text = text.Replace("{diaChiB}", diaChi);
            text = text.Replace("{tenA}", tenCty);
            text = text.Replace("{namSinhA}", "  ");
            text = text.Replace("{diaChiA}", diaChiCty);
            text = text.Replace("{bienSo}", bienSoXe);
            text = text.Replace("{nhanHieu}", nhaHieu);
            string soLoai = "2";
            text = text.Replace("{soLoai}", soLoai);
            text = text.Replace("{loaiXe}", txtTenLoaiXe.Text);
            text = text.Replace("{mauSon}", mauSon);
            text = text.Replace("{thoiHanThue}", thoiHan);
            text = text.Replace("{thienThue}", txtTien.Text);
            string ngay = DateTime.Now.Day.ToString();
            string thang = DateTime.Now.Month.ToString();
            string nam = DateTime.Now.Year.ToString();
            text = text.Replace("{ngay}", ngay);
            text = text.Replace("{thang}", thang);
            text = text.Replace("{nam}", nam);
            text = text.Replace("ô tô", txtTenLoaiXe.Text.Split(' ')[1]);
              text = text.Replace("Ô Tô", txtTenLoaiXe.Text.Split(' ')[1]);



            string hopDong = $"{tenCty}|{"  "}|{diaChiCty}|{ten}|{ngaySinh.ToString("dd-MM-yyyy")}|{diaChi}|{bienSoXe}|{nhaHieu}|{soLoai}|{txtTenLoaiXe.Text}|{mauSon}|{thoiHan}|{tien}|{ngay}|{thang}|{nam}";
            int loai = 1;
            if (xt.addNguoiChoThueHoacThue(maNguoiDung, maXe, ten, ngaySinh, diaChi, hopDong, loai,tien) && xt.updateXeThueTinhTrang(maXe))
            {
             //   MessageBox.Show("Them thanh cong", "Thong bao", MessageBoxButtons.OK);

                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Word Documents (*.docx)|*.docx";

                sfd.FileName = "hopdongxe.docx";
                string output = "";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    output = sfd.FileName;
                }
                File.WriteAllText(Ulti.html, text);
                string input = Ulti.html;
            //     output = Ulti.fileSave;
                if (File.Exists(input))
                {
                    SautinSoft.Document.DocumentCore oDocumentCore = SautinSoft.Document.DocumentCore.Load(input);
                    oDocumentCore.Save(output);
                }

                // Open the result for demonstration purposes.
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(output) { UseShellExecute = true });

                File.Delete(Ulti.html);

            }
            else
                MessageBox.Show("Them that bai", "Thong bao", MessageBoxButtons.OK);
        }
    }
}
