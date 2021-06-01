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
    public partial class QuanLyTho : Form
    {
        Woker wk = new Woker();
        private int maCu;
        int maNV;
        int maCM;
        string hoTen;
        DateTime ngaySinh;
        string gioiTinh;
        string diaChi;
        string sdt;
        string email;
        int condition = 0;
        string value = "";
        public QuanLyTho(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }


        private void QuanLyTho_Load(object sender, EventArgs e)
        {
            dgvWorkers.DataSource = wk.getFullWorkers();
            dgvWorkers.AllowUserToAddRows = false;
            dgvWorkers.ReadOnly = true;
            dgvWorkers.Columns[0].Width = 50;
            // nv.maNV,nv.hoTen,nv.ngaySinh,nv.gioiTinh,nv.diaChi,nv.sdt,nv.email,cm.tenCM
            dgvWorkers.Columns["maNV"].HeaderText = "Mã NV";
            dgvWorkers.Columns["hoTen"].HeaderText = "Họ tên";
            dgvWorkers.Columns["ngaySinh"].HeaderText = "Ngày sinh";
            dgvWorkers.Columns["diaChi"].HeaderText = "Địa chỉ";
            dgvWorkers.Columns["sdt"].HeaderText = "Số điện thoại";
            dgvWorkers.Columns["email"].HeaderText = "Email";
            dgvWorkers.Columns["tenCM"].HeaderText = "Chuyên môn";

            loadDataComboBox(cbChuyenMon);
            loadDataComboBox(cbShowRole);
            cbShowRole.SelectedValueChanged += CbChuyenMon_SelectedValueChanged;
        }

        private void CbChuyenMon_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvWorkers.DataSource = wk.getFullWorkersByRole((int)cbShowRole.SelectedValue,value,condition);
        }

        void loadDataComboBox(ComboBox cb)
        {
            cb.DataSource = wk.getChuyenMon();
            cb.DisplayMember = "tenCM";
            cb.ValueMember = "maCM";
        }

        private void btnShowFull_Click(object sender, EventArgs e)
        {
            dgvWorkers.DataSource = wk.getFullWorkers();
             condition = 0;
             value = "";
            txtTim.Text = "";
        }

        private void dgvWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            maCu = (int)dgvWorkers.Rows[e.RowIndex].Cells[0].Value;
            this.txtMaNV.Text = dgvWorkers.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.txtTen.Text = dgvWorkers.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvWorkers.Rows[e.RowIndex].Cells[2].Value;
            if (dgvWorkers.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
                radNu.Checked = true;
            this.rtxtDiachi.Text = dgvWorkers.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.txtDienThoai.Text = dgvWorkers.Rows[e.RowIndex].Cells[5].Value.ToString();
            this.txtEmail.Text = dgvWorkers.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbChuyenMon.SelectedIndex = cbChuyenMon.FindString(dgvWorkers.Rows[e.RowIndex].Cells[7].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            assigValues();
            if (wk.addWorker(maNV, maCM, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email))
            {
                MessageBox.Show("Them thanh cong", "Thong bao", MessageBoxButtons.OK);
                dgvWorkers.DataSource = wk.getFullWorkers();
                ClearText();
            }
            else
                MessageBox.Show("Them that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            assigValues();
            if (wk.updateWorker(maNV, maCM, hoTen, ngaySinh, gioiTinh, diaChi, sdt, email))
            {
                MessageBox.Show("Sua thanh cong", "Thong bao", MessageBoxButtons.OK);
                dgvWorkers.DataSource = wk.getFullWorkers();
                ClearText();
            }
            else
                MessageBox.Show("Sua that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            assigValues();
            if (wk.removeWorker(maNV))
            {
                MessageBox.Show("Xoa thanh cong", "Thong bao", MessageBoxButtons.OK);
                dgvWorkers.DataSource = wk.getFullWorkers();
                ClearText();
            }
            else
                MessageBox.Show("Xoa that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearText();
        }
        void ClearText()
        {

            txtMaNV.Text = "";
            cbChuyenMon.SelectedIndex = -1;
            txtTen.Text = "";
            ngaySinh = dtpNgaySinh.Value;
            radNam.Checked = true;
            rtxtDiachi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";

        }
        void assigValues()
        {
            maNV = int.Parse(txtMaNV.Text);
            maCM = (int)cbChuyenMon.SelectedValue;
            hoTen = txtTen.Text.Trim();
            ngaySinh = dtpNgaySinh.Value;
            gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            diaChi = rtxtDiachi.Text.Trim();
            sdt = txtDienThoai.Text.Trim();
            email = txtEmail.Text.Trim();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim() == "")
            {
                MessageBox.Show("Khong co gi de tim");
                return;
            }

            //int condition = 0;
            //string value = "";
            if (IsDigitsOnly(txtTim.Text.Trim()))
            {
                value = txtTim.Text.Trim();
                condition = 1;
            }
            else
            {
                foreach (char c in txtTim.Text.Trim())
                {
                    if (c > '0' && c < '9')
                    {

                        MessageBox.Show("Nhap sai roi ");
                        return;
                    }


                }
                value = txtTim.Text.Trim();
                condition = 2;
            }
            if (!ckbLoc.Checked)
                dgvWorkers.DataSource = wk.FindWorkerByIdOrName(value, condition);
            else
                CbChuyenMon_SelectedValueChanged(sender, e);
        }
         bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            value = txtTim.Text;
        }
    }
}
