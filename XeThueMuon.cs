using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamSocXe
{
    class XeThueMuon
    {
        MyDatabase data = new MyDatabase();
        public DataTable getLoaiXe()
        {
            string query = $"SELECT * FROM LoaiXe";
            return data.getTable(query);
        }


        public bool addXeVoThue(int maXe, string bienSoXe, Image anhXe, string mauSon, string maLoaiXe, string nhanHieu, string thoiHan)
        {
            string query = @"INSERT INTO dbo.XeChoThue
        (
            maXe,
            bienSoXe,
            anhXe,
            mauSon,
            maLoaiXe,
            nhaHieu,
            tinhTrang,
            thoiHan
        ) " +
        $"VALUES({maXe}, N'{bienSoXe}',@anhXe, N'{mauSon}', N'{maLoaiXe}',N'{nhanHieu}',0,N'{thoiHan}')";


            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@anhXe", Ulti.ImageToByteArray(anhXe)));
            return data.ExecuteNonQuery(query, parameters.ToArray());




        }
        public bool addNguoiChoThueHoacThue(int maNguoiDung, int maXe, string ten,  DateTime ngaySinh, string diaChi, string hopDong , int loai)
        {


            string query = @"INSERT INTO dbo.NguoiThueHoacChoThue
            (
                maNguoiDung,
                maXe,
                ten,
                ngaySinh,
                diaChi,
                hopDong,
                loai
            ) " +
            $"VALUES({maNguoiDung},{maXe},N'{ten}', N'{ngaySinh}', N'{diaChi}',N'{hopDong}',{loai})";



            return data.ExecuteNonQuery(query);




        }
    }
}
