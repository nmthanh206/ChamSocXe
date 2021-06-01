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
    public partial class QuanLyTheXe : Form
    {
        MyDatabase data = new MyDatabase();
        string theCu;
        public QuanLyTheXe(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;

       
        }

        private void QuanLyTheXe_Load(object sender, EventArgs e)
        {
            DataTable dt= data.getTable("SELECT * FROM TheXe");
            dgvTheXe.DataSource = addCheckBox(dt);
            dgvTheXe.Columns["soThe"].HeaderText = "Mã Số Thẻ";
            dgvTheXe.AllowUserToAddRows = false;
            dgvTheXe.ReadOnly = true;

        }
        private DataTable addCheckBox(DataTable dt)
        {
            dt.Columns.Add("Đang sử dung", typeof(bool));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool done = ((int)dt.Rows[i]["tinhTrang"]) == 1 ? true : false;
                dt.Rows[i][dt.Columns.Count - 1] = done;
            }
            dt.Columns.Remove("tinhTrang");

            return dt;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (data.ExecuteNonQuery($"INSERT INTO TheXE VALUES (N'{txtThe.Text}',0)"))
            {
                MessageBox.Show("Them thanh cong");
                dgvTheXe.DataSource = addCheckBox(data.getTable("SELECT * FROM TheXe"));
            }
            else
                MessageBox.Show("Them that bai");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (data.ExecuteNonQuery($"UPDATE TheXE SET soThe=N'{txtThe.Text}' WHERE soThe=N'{theCu}'")) 
            {
                MessageBox.Show("Sua thanh cong");
                dgvTheXe.DataSource = addCheckBox(data.getTable("SELECT * FROM TheXe"));
            }
            else
                MessageBox.Show("sua that bai");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (data.ExecuteNonQuery($"DELETE FROM TheXE WHERE soThe=N'{txtThe.Text}'"))
            {
                MessageBox.Show("Xoa thanh cong");
                dgvTheXe.DataSource = addCheckBox(data.getTable("SELECT * FROM TheXe"));
            }
            else
                MessageBox.Show("Xoa that bai");
        }

        private void dgvTheXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

        theCu= dgvTheXe.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtThe.Text = theCu;
        }
    }
}
