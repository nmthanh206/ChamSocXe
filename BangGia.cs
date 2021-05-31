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
    public partial class BangGia : Form
    {
        Xe gx = new Xe();
        List<int> giaTienXe = new List<int>();
        public BangGia(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void BangGia_Load(object sender, EventArgs e)
        {
            cbDichVu.DataSource = gx.getDichVu();
            cbDichVu.DisplayMember = "tenDichVu";
            cbDichVu.ValueMember = "maDichVu";


            txtXeDap.KeyPress += TxtXeDap_KeyPress;
            txtXeMay.KeyPress += TxtXeDap_KeyPress;
            txtXeHoi.KeyPress += TxtXeDap_KeyPress;
            cbDichVu.SelectedValueChanged += CbDichVu_SelectedValueChanged;

        }

        private void CbDichVu_SelectedValueChanged(object sender, EventArgs e)
        {
            int maDichVu = (int)cbDichVu.SelectedValue;
            if (maDichVu==1)
            {
                lblDonVi1.Text = lblDonVi2.Text = lblDonVi3.Text = "/Giờ";
            }
            else
            {
                lblDonVi1.Text = lblDonVi2.Text = lblDonVi3.Text = "/Chiếc";
            }

            giaTienXe = gx.getTienXe(maDichVu);
            txtXeDap.Text = $"{ giaTienXe[0]}";
            txtXeMay.Text = $"{ giaTienXe[1]}";
            txtXeHoi.Text = $"{ giaTienXe[2]}";
        }

        private void TxtXeDap_KeyPress(object sender, KeyPressEventArgs e)
        {
          
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int maDichVu = (int)cbDichVu.SelectedValue;
            string[] gia= { txtXeDap.Text, txtXeMay.Text, txtXeHoi.Text };
            if (gx.updateGia(maDichVu,gia))
            {
                MessageBox.Show("Cap nhat thanh cong", "Thong bao", MessageBoxButtons.OK);
                CbDichVu_SelectedValueChanged(sender, e);
            }
            else
                MessageBox.Show("Cap nhat that bai", "Thong bao", MessageBoxButtons.OK);
        }
    }
}
