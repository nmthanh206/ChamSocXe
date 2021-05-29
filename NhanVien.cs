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
    public partial class NhanVien : Form
    {
        Woker wk = new Woker();
        GoiXe parent;
        public NhanVien(int maDichVu,string tenDichVu,GoiXe parent)
        {
        
            InitializeComponent();
            lblLoaiNhanVien.Text = $" Danh Sách Nhân Viên {tenDichVu}";
            lbNhanVien.DataSource = wk.getFullWorkersByRole(maDichVu);
            lbNhanVien.DisplayMember = "hoTen";
            lbNhanVien.ValueMember = "maNV";
            this.parent = parent;
           
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {

        }

        private void lbNhanVien_DoubleClick(object sender, EventArgs e)
        {
            parent.MaNV = (int)lbNhanVien.SelectedValue;
            parent.tenNV = lbNhanVien.GetItemText(lbNhanVien.SelectedItem);
            this.Close();

        }
    }
}
