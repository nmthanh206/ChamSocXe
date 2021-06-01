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
            btnLuu.Visible = false;
        }

        private void DanhSachXeSuDungDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVuXe.RowTemplate.Height = 80;
            DataTable dt = gx.getDanhSachXeDichVu2();

            indexCheckBox = dt.Columns.Count - 1;
            dgvDichVuXe.DataSource = addCheckBox(dt);


            DataGridViewImageColumn anhTruocXe = new DataGridViewImageColumn();
            anhTruocXe = (DataGridViewImageColumn)dgvDichVuXe.Columns["anhPhiaTruoc"];
            anhTruocXe.ImageLayout = DataGridViewImageCellLayout.Stretch;


            DataGridViewImageColumn anhSauXe = new DataGridViewImageColumn();
            anhSauXe = (DataGridViewImageColumn)dgvDichVuXe.Columns["anhPhiaSau"];
            anhSauXe.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dgvDichVuXe.AllowUserToAddRows = false;
             dgvDichVuXe.ReadOnly = true;
            // dgvDichVuXe.ReadOnly = false;
            //for (int i = 0; i < dgvDichVuXe.Columns.Count-1; i++)
            //{
            //    dgvDichVuXe.Columns[i].ReadOnly = true;
            //}


            //DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            //dgvCmb.ValueType = typeof(bool);
            //dgvCmb.Name = "Chk";
            //dgvCmb.HeaderText = "CheckBox";
            //dgvDichVuXe.Columns.Add(dgvCmb);



            dgvDichVuXe.Columns["id"].Visible = false;

            // x.id,x.soThe,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,nv.hoTen,x.ngayGioVao,x.ngayGioRa,x.tinhTrang,x.phi 
            dgvDichVuXe.Columns["soThe"].HeaderText = "Thẻ xe số";
            dgvDichVuXe.Columns["bienSoXe"].HeaderText = "Biển Số";
            dgvDichVuXe.Columns["tenLoaiXe"].HeaderText = "Loại Xe";
            dgvDichVuXe.Columns["tenDichVu"].HeaderText = "Dịch Vụ";
            dgvDichVuXe.Columns["loaiGoi"].HeaderText = "Hình Thức(nếu có)";
            dgvDichVuXe.Columns["ngayGioVao"].HeaderText = "Ngày giờ vào";
            dgvDichVuXe.Columns["ngayGioRa"].HeaderText = "Ngày giờ ra";
            dgvDichVuXe.Columns["anhPhiaTruoc"].HeaderText = "Ảnh trước";
            dgvDichVuXe.Columns["anhPhiaSau"].HeaderText = "Ảnh sau";
            dgvDichVuXe.Columns["hoTen"].HeaderText = "Nhân viên phụ trách";
            dgvDichVuXe.Columns["phi"].HeaderText = "Tiền trả";
            cbDichVu.DataSource = gx.getDichVu();
            cbDichVu.DisplayMember = "tenDichVu";
            cbDichVu.ValueMember = "maDichVu";

            cbDichVu.SelectedValueChanged += CbDichVu_SelectedValueChanged;

        }
         private DataTable addCheckBox(DataTable dt) 
        {
            dt.Columns.Add("STT", typeof(int)).SetOrdinal(0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = i+1;
            }
            dt.Columns.Add("Khách đã lấy xe", typeof(bool));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool done = ((int)dt.Rows[i]["tinhTrang"]) == 1 ? true : false;
                dt.Rows[i][dt.Columns.Count - 1] = done;
            }
            dt.Columns.Remove("tinhTrang");
       
            return dt;
        }

        private void CbDichVu_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvDichVuXe.DataSource = addCheckBox( gx.getDanhSachXeDichVu($"WHERE x.maDichVu={(int)cbDichVu.SelectedValue}"));
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dgvDichVuXe.DataSource = addCheckBox(gx.getDanhSachXeDichVu());
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
            dgvDichVuXe.DataSource = addCheckBox( gx.timSoXe($"WHERE x.bienSoXe LIKE '%" + bienSoXe + "%'"));
        }
    }
}
