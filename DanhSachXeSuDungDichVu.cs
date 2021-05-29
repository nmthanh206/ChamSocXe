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
        public DanhSachXeSuDungDichVu(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void DanhSachXeSuDungDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVuXe.RowTemplate.Height = 80;
            dgvDichVuXe.DataSource = gx.getDanhSachXeDichVu();

            DataGridViewImageColumn anhTruocXe = new DataGridViewImageColumn();
            anhTruocXe = (DataGridViewImageColumn)dgvDichVuXe.Columns[3];
            anhTruocXe.ImageLayout = DataGridViewImageCellLayout.Stretch;


            DataGridViewImageColumn anhSauXe = new DataGridViewImageColumn();
            anhSauXe = (DataGridViewImageColumn)dgvDichVuXe.Columns[4];
            anhSauXe.ImageLayout = DataGridViewImageCellLayout.Stretch;


            dgvDichVuXe.AllowUserToAddRows = false;
            dgvDichVuXe.ReadOnly = true;
        }


    }
}
