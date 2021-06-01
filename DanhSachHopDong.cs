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
    public partial class DanhSachHopDong : Form
    {
        public DanhSachHopDong(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
        }

        private void DanhSachHopDong_Load(object sender, EventArgs e)
        {

        }
    }
}
