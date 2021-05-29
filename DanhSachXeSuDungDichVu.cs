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
    public partial class DanhSachXeSuDungDichVu : Form
    {
        Xe gx = new Xe();
        int indexCheckBox;
        public DanhSachXeSuDungDichVu(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void DanhSachXeSuDungDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVuXe.RowTemplate.Height = 80;
            DataTable dt = gx.getDanhSachXeDichVu();

            dt.Columns.Add("Đã Xong", typeof(bool));



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool done = ((int)dt.Rows[i]["tinhTrang"]) == 1 ? true : false;
                dt.Rows[i][dt.Columns.Count - 1] = done;
            }
            dt.Columns.Remove("tinhTrang");
            indexCheckBox = dt.Columns.Count - 1;
            dgvDichVuXe.DataSource = dt;


            DataGridViewImageColumn anhTruocXe = new DataGridViewImageColumn();
            anhTruocXe = (DataGridViewImageColumn)dgvDichVuXe.Columns["anhPhiaTruoc"];
            anhTruocXe.ImageLayout = DataGridViewImageCellLayout.Stretch;


            DataGridViewImageColumn anhSauXe = new DataGridViewImageColumn();
            anhSauXe = (DataGridViewImageColumn)dgvDichVuXe.Columns["anhPhiaSau"];
            anhSauXe.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dgvDichVuXe.AllowUserToAddRows = false;
             dgvDichVuXe.ReadOnly = false;
            for (int i = 0; i < dgvDichVuXe.Columns.Count-1; i++)
            {
                dgvDichVuXe.Columns[i].ReadOnly = true;
            }
           

            //DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            //dgvCmb.ValueType = typeof(bool);
            //dgvCmb.Name = "Chk";
            //dgvCmb.HeaderText = "CheckBox";
            //dgvDichVuXe.Columns.Add(dgvCmb);






            cbDichVu.DataSource = gx.getDichVu();
            cbDichVu.DisplayMember = "tenDichVu";
            cbDichVu.ValueMember = "maDichVu";

            cbDichVu.SelectedValueChanged += CbDichVu_SelectedValueChanged;

        }

        private void CbDichVu_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvDichVuXe.DataSource = gx.getDanhSachXeDichVu($"WHERE x.maDichVu={(int)cbDichVu.SelectedValue}");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dgvDichVuXe.DataSource = gx.getDanhSachXeDichVu();
            txtTimSoXe.Text = "";
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            List<bool> done = new List<bool>();
            List<int> ids = new List<int>();
            for (int i = 0; i < dgvDichVuXe.Rows.Count; i++)
            {
                bool ckb = (bool)dgvDichVuXe.Rows[i].Cells[indexCheckBox].Value;
                int id = (int)dgvDichVuXe.Rows[i].Cells[0].Value;
                done.Add(ckb);
                ids.Add(id);
            }
            if (gx.updateXedichVu(ids, done))
                MessageBox.Show("Cap nhat thanh cong", "Thong bao", MessageBoxButtons.OK);
            else
                MessageBox.Show("Cap nhat that bai", "Thong bao", MessageBoxButtons.OK);

        }

        private void btnTimSoXe_Click(object sender, EventArgs e)
        {
            string bienSoXe = txtTimSoXe.Text.Trim();
            dgvDichVuXe.DataSource = gx.timSoXe($"WHERE x.bienSoXe LIKE '%" + bienSoXe + "%'");
        }
    }
}
