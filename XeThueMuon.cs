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
        public DataTable getXeThue()
        {
            string query = $"SELECT xt.maXe,lx.maLoaiXe,lx.tenLoaiXe,xt.bienSoXe,xt.mauSon,xt.nhaHieu,xt.anhXe,xt.thoiHan,xt.tinhTrang " +
                            $"FROM dbo.XeChoThue xt JOIN dbo.LoaiXe lx ON lx.maLoaiXe = xt.maLoaiXe";
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
        public bool addNguoiChoThueHoacThue(int maNguoiDung, int maXe, string ten,  DateTime ngaySinh, string diaChi, string hopDong , int loai,int tien)
        {
            string query = @"INSERT INTO dbo.NguoiThueHoacChoThue
            (
                maNguoiDung,
                maXe,
                ten,
                ngaySinh,
                diaChi,
                hopDong,
                loai,
                tien
            ) " +
            $"VALUES({maNguoiDung},{maXe},N'{ten}', N'{ngaySinh}', N'{diaChi}',N'{hopDong}',{loai},{tien})";
            return data.ExecuteNonQuery(query);
        }
        public bool updateXeThueTinhTrang(int maXe)
        {
            string query = $"UPDATE dbo.XeChoThue SET tinhTrang=1 WHERE maXe={maXe}";
            return data.ExecuteNonQuery(query);
        }

        public DataTable getDanhSAchHopDong()
        {
            string query = @"SELECT nt.maXe,xt.bienSoXe,lx.tenLoaiXe,nt.ten,nt.ngaySinh,l.ten[ten2],xt.thoiHan,xt.mauSon,xt.nhaHieu,xt.anhXe,nt.tien,nt.hopDong
FROM dbo.NguoiThueHoacChoThue nt JOIN dbo.XeChoThue xt ON xt.maXe=nt.maXe
JOIN dbo.loaiNguoiDung l ON l.loai=nt.loai JOIN dbo.LoaiXe lx ON lx.maLoaiXe=xt.maLoaiXe";
            return data.getTable(query); ;
        }
    }
}
