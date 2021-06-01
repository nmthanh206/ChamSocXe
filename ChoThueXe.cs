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
    public partial class ChoThueXe : Form
    {
        XeThueMuon xt = new XeThueMuon();
        public ChoThueXe(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
            dgvXeChoThue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        string maXe; 
        string bienSoXe; 
        Image anhxe; 
        string mauSon; 
        string maLoaiXe;
        string tenLoaiXe;
        string nhaHieu; 
        string thoiHan;
        bool tinhTrang;

        private void dataGridView1_DoubleClick(object sender, EventArgs e)

        { 
            if(tinhTrang)
            {
                MessageBox.Show("Xe nay co nguoi thue roi");
                return;
            }
            string[] data = { maXe, bienSoXe, mauSon, maLoaiXe, tenLoaiXe, nhaHieu, thoiHan };
            NguoiThue ntf = new NguoiThue(data,anhxe);
            ntf.ShowDialog();
        }

        private void ChoThueXe_Load(object sender, EventArgs e)
        {
            dgvXeChoThue.RowTemplate.Height = 80;
            DataTable dt = xt.getXeThue();
            dgvXeChoThue.DataSource = addCheckBox(dt);

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dgvXeChoThue.Columns["anhXe"];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dgvXeChoThue.AllowUserToAddRows = false;
            dgvXeChoThue.ReadOnly = true;
            dgvXeChoThue.Columns["maLoaiXe"].Visible = false;

            dgvXeChoThue.Columns["maXe"].HeaderText = "Mã Xe";
            dgvXeChoThue.Columns["tenLoaiXe"].HeaderText = "Loại Xe";
            dgvXeChoThue.Columns["bienSoXe"].HeaderText = "Biển Số";

            dgvXeChoThue.Columns["anhXe"].HeaderText = "Ảnh";
            dgvXeChoThue.Columns["mauSon"].HeaderText = "Màu";
            dgvXeChoThue.Columns["nhaHieu"].HeaderText = "Nhãn Hiệu";
            dgvXeChoThue.Columns["thoiHan"].HeaderText = "Có thể thuê";
          
        }
        private DataTable addCheckBox(DataTable dt)
        {
            dt.Columns.Add("Đã có người thuê", typeof(bool));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool done = ((int)dt.Rows[i]["tinhTrang"]) == 1 ? true : false;
                dt.Rows[i][dt.Columns.Count - 1] = done;
            }
            dt.Columns.Remove("tinhTrang");

            return dt;
        }

        private void dgvXeChoThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            //T xt.maXe,lx.maLoaiXe,lx.tenLoaiXe,xt.bienSoXe,xt.mauSon,xt.nhaHieu,xt.anhXe,xt.thoiHan,xt.tinhTrang 
            maXe = dgvXeChoThue.Rows[e.RowIndex].Cells[0].Value.ToString();
            tenLoaiXe = dgvXeChoThue.Rows[e.RowIndex].Cells[2].Value.ToString();
            bienSoXe = dgvXeChoThue.Rows[e.RowIndex].Cells[3].Value.ToString();
            
             mauSon= dgvXeChoThue.Rows[e.RowIndex].Cells[4].Value.ToString();          
             nhaHieu = dgvXeChoThue.Rows[e.RowIndex].Cells[5].Value.ToString();
            anhxe = Ulti.byteArrayToImage((byte[])dgvXeChoThue.Rows[e.RowIndex].Cells[6].Value);
            thoiHan = dgvXeChoThue.Rows[e.RowIndex].Cells[7].Value.ToString(); 
            maLoaiXe= dgvXeChoThue.Rows[e.RowIndex].Cells["maLoaiXe"].Value.ToString();
            tinhTrang = (bool)dgvXeChoThue.Rows[e.RowIndex].Cells[8].Value;
        }
    }
}
