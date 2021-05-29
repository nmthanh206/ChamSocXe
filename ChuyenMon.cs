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
    public partial class ChuyenMon : Form
    {
        Woker wk = new Woker();
        public ChuyenMon(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void ChuyenMon_Load(object sender, EventArgs e)
        {
            LoadComboBox(cbEdit);
            LoadComboBox(cbRemove);
        }
        void LoadComboBox(ComboBox cb)
        {
          
            cb.DataSource = wk.getChuyenMon();
            cb.DisplayMember = "tenCM";
            cb.ValueMember = "maCM";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (wk.addCM(int.Parse(txtId.Text), txtAdd.Text.Trim()))
            {
                MessageBox.Show("Them thanh cong", "Thong bao", MessageBoxButtons.OK);
                ChuyenMon_Load(sender, e);
                txtId.Text = "";
                
            }
            else
                MessageBox.Show("Them that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(wk.updateCM((int)cbEdit.SelectedValue, txtEdit.Text.Trim()))
            {
                MessageBox.Show("Sua thanh cong", "Thong bao", MessageBoxButtons.OK);
                ChuyenMon_Load(sender, e);
                txtEdit.Text = "";
            }
            else
                MessageBox.Show("Sua that bai", "Thong bao", MessageBoxButtons.OK);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
           
            if(wk.removeCM((int)cbRemove.SelectedValue))
            {
                MessageBox.Show("Xoa thanh cong", "Thong bao", MessageBoxButtons.OK);
                ChuyenMon_Load(sender, e);
            }
            else
                MessageBox.Show("Xoa that bai", "Thong bao", MessageBoxButtons.OK);
        }
    }
}
