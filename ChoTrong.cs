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
    public partial class ChoTrong : Form
    {
        MyDatabase data = new MyDatabase();
        public ChoTrong()
        {
            InitializeComponent();
        }
        string maLoaiXe = "";
        private void ChoTrong_Load(object sender, EventArgs e)
        {

            dgvChoTrong.DataSource = data.getTable("SELECT lx.tenLoaiXe,ct.soChoToiDa,ct.soChoDaDung,ct.maLoaiXe FROM dbo.LoaiXe lx JOIN ChoTrong ct On ct.maLoaiXe=lx.maLoaiXe");
            dgvChoTrong.Columns["maLoaiXe"].Visible = false;

            dgvChoTrong.AllowUserToAddRows = false;
            dgvChoTrong.ReadOnly = true;
            txtCon.KeyPress += TxtCon_KeyPress;
            txtToiDa.KeyPress += TxtCon_KeyPress;
        }

        private void TxtCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void dgvChoTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            maLoaiXe = dgvChoTrong.Rows[e.RowIndex].Cells[3].Value.ToString();
            lblXe.Text = dgvChoTrong.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtToiDa.Text = dgvChoTrong.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCon.Text = dgvChoTrong.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (data.ExecuteNonQuery($"UPDATE dbo.ChoTrong SET soChoDaDung={txtCon.Text},soChoToiDa={txtToiDa.Text} WHERE maLoaiXe=N'{maLoaiXe}'"))
            {
                MessageBox.Show("Cap nhat thanh cong", "Thong bao", MessageBoxButtons.OK);
                dgvChoTrong.DataSource = data.getTable("SELECT lx.tenLoaiXe,ct.soChoToiDa,ct.soChoDaDung,ct.maLoaiXe FROM dbo.LoaiXe lx JOIN ChoTrong ct On ct.maLoaiXe=lx.maLoaiXe");

            }
            else
                MessageBox.Show("Cap nhat that bai", "Thong bao", MessageBoxButtons.OK);
        }
    }
}
