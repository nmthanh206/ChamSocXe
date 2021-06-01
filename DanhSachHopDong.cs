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
    public partial class DanhSachHopDong : Form
    {
        XeThueMuon xt = new XeThueMuon();
        string []hopDong ;
        string tenLoaiXe;
        public DanhSachHopDong(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DanhSachHopDong_Load(object sender, EventArgs e)
        {
            dgvHopDong.RowTemplate.Height = 80;
            DataTable dt = xt.getDanhSAchHopDong();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][6]= dt.Rows[i][11].ToString().Split('|')[11];
            }
            dgvHopDong.DataSource = dt;

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dgvHopDong.Columns["anhXe"];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dgvHopDong.AllowUserToAddRows = false;
            dgvHopDong.ReadOnly = true;
            dgvHopDong.Columns["hopDong"].Visible = false;

            //--rename
            dgvHopDong.Columns["maXe"].HeaderText = "Mã Xe";
            dgvHopDong.Columns["tenLoaiXe"].HeaderText = "Loại Xe";
            dgvHopDong.Columns["bienSoXe"].HeaderText = "Biển Số";
            dgvHopDong.Columns["ten"].HeaderText = "Họ Tên";
            dgvHopDong.Columns["ten2"].HeaderText = "Vai Trò";
            dgvHopDong.Columns["anhXe"].HeaderText = "Ảnh";
            dgvHopDong.Columns["mauSon"].HeaderText = "Màu";
            dgvHopDong.Columns["nhaHieu"].HeaderText = "Nhãn Hiệu";
            dgvHopDong.Columns["thoiHan"].HeaderText = "Có thể thuê/tháng";
            dgvHopDong.Columns["tien"].HeaderText = "Tiền trả";
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            hopDong = dgvHopDong.Rows[e.RowIndex].Cells[11].Value.ToString().Split('|');
            tenLoaiXe = dgvHopDong.Rows[e.RowIndex].Cells[2].Value.ToString().Split(' ')[1];
           
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(Ulti.filepath);

            text = text.Replace("{tenA}", hopDong[0]);
            text = text.Replace("{namSinhA}", hopDong[1]);
            text = text.Replace("{diaChiA}", hopDong[2]);
            text = text.Replace("{tenB}", hopDong[3]);
            text = text.Replace("{namSinhB}", hopDong[4]);
            text = text.Replace("{diaChiB}", hopDong[5]);
            text = text.Replace("{bienSo}", hopDong[6]);
            text = text.Replace("{nhanHieu}", hopDong[7]);
            //  string soLoai = "2";
            text = text.Replace("{soLoai}", hopDong[8]);
            text = text.Replace("{loaiXe}", hopDong[9]);
            text = text.Replace("{mauSon}", hopDong[10]);
            text = text.Replace("{thoiHanThue}", hopDong[11]);
            text = text.Replace("{thienThue}", hopDong[12]);
            text = text.Replace("{ngay}", hopDong[13]);
            text = text.Replace("{thang}", hopDong[14]);
            text = text.Replace("{nam}", hopDong[15]);
            text = text.Replace("ô tô", tenLoaiXe);
            text = text.Replace("Ô Tô", tenLoaiXe);
            //  string hopDong = $"{ten}|{ngaySinh.ToString("dd-MM-yyyy")}|{diaChi}|{tenCty}|{"  "}|{diaChiCty}|{bienSoXe}|{nhaHieu}|{soLoai}|{cbLoaiXe.Text}|{mauSon}|{thoiHan}|{tien}";
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
        }
    }
}
