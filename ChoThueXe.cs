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


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string[] data = { maXe, bienSoXe, mauSon, maLoaiXe, tenLoaiXe, nhaHieu, thoiHan };
            NguoiThue ntf = new NguoiThue(data,anhxe);
            ntf.ShowDialog();
        }

        private void ChoThueXe_Load(object sender, EventArgs e)
        {
            dgvXeChoThue.RowTemplate.Height = 80;
            dgvXeChoThue.DataSource = xt.getXeThue();

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dgvXeChoThue.Columns["anhXe"];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dgvXeChoThue.AllowUserToAddRows = false;
            dgvXeChoThue.ReadOnly = true;
            dgvXeChoThue.Columns["maLoaiXe"].Visible = false;
        }

        private void dgvXeChoThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             maXe = dgvXeChoThue.Rows[e.RowIndex].Cells["maXe"].Value.ToString();
            tenLoaiXe = dgvXeChoThue.Rows[e.RowIndex].Cells["tenLoaiXe"].Value.ToString();
            bienSoXe = dgvXeChoThue.Rows[e.RowIndex].Cells["bienSoXe"].Value.ToString();
             anhxe=Ulti.byteArrayToImage((byte[])dgvXeChoThue.Rows[e.RowIndex].Cells["anhXe"].Value);
             mauSon= dgvXeChoThue.Rows[e.RowIndex].Cells["mauSon"].Value.ToString();
            
             nhaHieu = dgvXeChoThue.Rows[e.RowIndex].Cells["nhaHieu"].Value.ToString();
             thoiHan= dgvXeChoThue.Rows[e.RowIndex].Cells["thoiHan"].Value.ToString(); 
            maLoaiXe= dgvXeChoThue.Rows[e.RowIndex].Cells["maLoaiXe"].Value.ToString();
        }
    }
}
