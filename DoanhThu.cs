using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocXe
{
    public partial class DoanhThu : Form
    {
        Xe gx = new Xe();
        MyDatabase data = new MyDatabase();
        DataTable dt;
        public DoanhThu(Form parent)
        {
            InitializeComponent();
            this.Width = parent.Width;
            this.Height = parent.Height;
            radDichVu.Checked = true;
        }
        int tongDoanhThu = 0;
        string [] listName ={"Trông coi xe","Sửa Xe","Rửa Xe"};
        int indexColumns = 3;
        private void DoanhThu_Load(object sender, EventArgs e)
        {

            dt = LoadData();

            dgvDoanhThu.DataSource = dt;
            dgvDoanhThu.AllowUserToAddRows = false;
            dgvDoanhThu.ReadOnly = true;

            cbDichVu.DataSource = gx.getDichVu();
            cbDichVu.DisplayMember = "tenDichVu";
            cbDichVu.ValueMember = "maDichVu";

            // x.bienSoXe,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,x.ngayGioVao,x.ngayGioRa,x.phi
            dgvDoanhThu.Columns["bienSoXe"].HeaderText = "Biển Số";
            dgvDoanhThu.Columns["tenLoaiXe"].HeaderText = "Loại Xe";
            dgvDoanhThu.Columns["tenDichVu"].HeaderText = "Dịch Vụ";
            dgvDoanhThu.Columns["loaiGoi"].HeaderText = "Hình thức (nếu có)";
            dgvDoanhThu.Columns["ngayGioVao"].HeaderText = "Ngày giờ vào";
            dgvDoanhThu.Columns["ngayGioRa"].HeaderText = "Ngày giờ ra";
            dgvDoanhThu.Columns["phi"].HeaderText = "Tiền trả";

            loadChart();
        }
        private void loadChart()
        {
            //foreach (var series in chartThongKe.Series)
            //{
            //    series.Points.Clear();
            //}
            double giuXe = 0;
            double ruaXe = 0;
            double suaXe = 0;
            int tong = dt.Rows.Count;
            for (int i = 0; i < tong; i++)
            {
                if (dt.Rows[i][indexColumns].ToString() == listName[0])
                    giuXe++;
                else if (dt.Rows[i][indexColumns].ToString() == listName[1])
                    suaXe++;
                else if (dt.Rows[i][indexColumns].ToString() == listName[2])
                    ruaXe++;
            }
            giuXe = Math.Round((giuXe*100 / tong),2);
            ruaXe = Math.Round((ruaXe*100 / tong), 2);
            suaXe = Math.Round(( 100-giuXe-ruaXe), 2);
            chartThongKe.Titles.Add("Thống Kê Sửa Dụng Dịch Vụ");
            chartThongKe.Series["s1"].IsValueShownAsLabel = true;
            chartThongKe.Series["s1"].Points.AddXY("Trông coi xe", giuXe);
            chartThongKe.Series["s1"].Points.AddXY("Sửa xe", suaXe);
            chartThongKe.Series["s1"].Points.AddXY("Rửa xe", ruaXe);
        }
        private DataTable LoadData()
        {
            dt = gx.getDoanhThu();
            dt.Columns.Add("STT", typeof(int)).SetOrdinal(0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                dt.Rows[i][0] = i + 1;
            }
            return dt;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dt = LoadData();

            dgvDoanhThu.DataSource = dt;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string tenDichVu = "";
            DateTime ra = new DateTime();
            DataTable newtb = dt.Copy();
            for (int i = 0; i < newtb.Rows.Count; i++)
            {
                //yyyy - MM - dd hh: mm: ss tt
                if (radNgay.Checked)
                {
                    ra = (DateTime)newtb.Rows[i]["ngayGioRa"];
                    if (!(ra.Day == dtpLoc.Value.Day && ra.Month == dtpLoc.Value.Month && ra.Year == dtpLoc.Value.Year))
                    {
                        newtb.Rows.RemoveAt(i);
                        i--;
                    }
                }
                else if (radDichVu.Checked)
                {
                    tenDichVu = $"{newtb.Rows[i]["tenDichVu"]}";
                    if (!(tenDichVu == cbDichVu.Text))
                    {
                        newtb.Rows.RemoveAt(i);
                        i--;
                    }

                }
                else
                {
                    ra = (DateTime)newtb.Rows[i]["ngayGioRa"];
                    tenDichVu = newtb.Rows[i]["tenDichVu"].ToString();
                    if (!(ra.Day == dtpLoc.Value.Day && ra.Month == dtpLoc.Value.Month && ra.Year == dtpLoc.Value.Year && tenDichVu == cbDichVu.Text))
                    {
                        newtb.Rows.RemoveAt(i);
                        i--;
                    }
                }

            }

            dgvDoanhThu.DataSource = newtb;
        }


      
        private void btnIn_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = $"Doanh Thu.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveWordHtml(dgvDoanhThu, sfd.FileName);
            }
            //string text = File.ReadAllText(@"C:\Users\THANH\Desktop\New folder\a.txt");

            //text = text.Replace("{tenA}", "Cu lì");
            //text = text.Replace("{namSinhA}", "2002");
            //text = text.Replace("{diaChiA}", "26a");
            //text = text.Replace("{tenB}", "");
            //text = text.Replace("{namSinhB}", "cu tre");
            //text = text.Replace("{diaChiB}", "11 vĩnh long");
            //text = text.Replace("{bienSo}", "1233WED");
            //text = text.Replace("{nhanHieu}", "BMW");
            //text = text.Replace("{soLoai}", "2");
            //text = text.Replace("{loaiXe}", "Mui trần");
            //text = text.Replace("{mauSon}", "Đen");
            //text = text.Replace("{thoiHanThue}", "6");


            //File.WriteAllText(@"C:\Users\THANH\Desktop\New folder\haha.html", text);



            //string input = @"C:\Users\THANH\Desktop\New folder\haha.html";
            //string output = @"C:\Users\THANH\Desktop\New folder\test.docx";
            //if (File.Exists(input))
            //{
            //    SautinSoft.Document.DocumentCore oDocumentCore = SautinSoft.Document.DocumentCore.Load(input);
            //    oDocumentCore.Save(output);
            //}

            //// Open the result for demonstration purposes.
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(output) { UseShellExecute = true });

        }
        void saveWordHtml(DataGridView dataGridView1, string FileName)
        {

            for (int i = 0; i < dgvDoanhThu.Rows.Count; i++)
            {
                tongDoanhThu += (int)dgvDoanhThu.Rows[i].Cells["phi"].Value;
            }
            //Table start.
            DateTime now = DateTime.Now;

            //    DateTime.Now.ToString("yyyy-MM-dd")
            string html = @"     <div style='font-size: 13px'>
      <div
        style='
          display: flex;
          align-items: center;
          justify-content: space-between;
          font-weight: bold;
        '
      >
        <p style=''>CÔNG TY CHĂM SÓC XE CHOMCHOMXYZ</p>" +
       $"  <p  style=''> Ngày in:&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp {now}</p>" +
     @" </div>
      <div>
        <p style='margin-left:4rem;text-decoration: underline;'>LUÔN TẬN TÂM</p>
      </div>
   
    <div style='text-align: center; font-weight: bold; margin-top: 23px;margin-bottom: 23px'>
      BẢNG DOANH THU CÔNG TY
    </div>
";




            html += "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";

            //Adding HeaderRow.
            html += "<tr>";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                html += $"<th style='background-color: #B8DBFD;border: 1px solid #ccc;text-align: center; vertical-align: middle;'>" +
                             $"<div style='border: none;'>" +
                                $"{ column.HeaderText}" +
                             $"</div>" +
                        $"</th>";
            }
            html += "</tr>";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                html += "<tr>";

                foreach (DataGridViewCell cell in row.Cells)
                {

                    html += $"<td style='width:120px;border: 1px solid #ccc;text-align: center; vertical-align: middle;'>" +
                                $"<div style='border: none;display: inline-block'>" +
                                   $"\n{cell.Value.ToString()}" +
                                $"</div>" +
                            $"</td>";
                }
                html += "</tr>";
            }
            //style='width:120px;border: 1px solid #ccc'  
            //display:flex;justify-content:center;align-items:center
            //Table end.
            html += "</table>";
            html += @" <div
      style='
        display: flex;
        align-items: center;
        justify-content: space-between;
        margin-top: -20px;
      '
    >" +
      $"<p>Tổng Doanh thu : {tongDoanhThu} </p>" +
     @" <div
        style='
          display: flex;
          flex-direction: column;
          align-items: center;
          justify-content: space-between;
        '
      >
        <p>Ngày_____tháng_____năm_______</p>
        <p  style='margin-left: 40px;margin-top: 40px'>Người In</p>
      </div>
    </div>
 </div>";
            //Save the HTML string as HTML File.

            string input = FileName.Replace(".docx", ".html");
            string output = FileName;


            File.WriteAllText(input, html);
            if (File.Exists(input))
            {
                SautinSoft.Document.DocumentCore oDocumentCore = SautinSoft.Document.DocumentCore.Load(input);
                oDocumentCore.Save(output);
            }

            // Open the result for demonstration purposes.
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(output) { UseShellExecute = true });


            File.Delete(input);
        }

        //private void btnDV_Click(object sender, EventArgs e)
        //{
        //    indexColumns = 3;
        //    listName = new string[3] { "Trông coi xe", "Sửa Xe", "Rửa Xe" };
        //    loadChart();
        //}

        //private void btnXe_Click(object sender, EventArgs e)
        //{
        //    indexColumns = 1;
        //    listName = new string[3] {"Xe Máy","Xe Mơi","Xe Đạp" };
        //    loadChart();
        //}
    }
}
