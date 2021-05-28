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
        public QuanLyTho()
        {
            InitializeComponent();
        }

        private void QuanLyTho_Load(object sender, EventArgs e)
        {
            dgvWorkers.DataSource = wk.getFullWorkers();
            dgvWorkers.AllowUserToAddRows = false;
            dgvWorkers.ReadOnly = true;
            loadDataComboBox(cbChuyenMon);
            loadDataComboBox(cbShowRole);
            cbShowRole.SelectedValueChanged += CbChuyenMon_SelectedValueChanged;
        }

        private void CbChuyenMon_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvWorkers.DataSource = wk.getFullWorkersByRole((int)cbShowRole.SelectedValue); 
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
        }

       
    }
}
