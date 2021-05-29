using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamSocXe
{
    class Xe
    {
        MyDatabase data = new MyDatabase();
        public DataTable getDichVu()
        {
            string query = $"SELECT * FROM DichVu";
            return data.getTable(query);
        }
        public DataTable getLoaiXe()
        {
            string query = $"SELECT * FROM LoaiXe";
            return data.getTable(query);
        }

        public bool addXe(string soThe,string bienSoXe,Image anhPhiaTruoc, Image anhPhiaSau, DateTime ngayGioVao, string maLoaiXe,int  maDichVu,int MaNV)
        {
            string query = $"INSERT INTO dbo.XeDichVu(soThe,bienSoXe,anhPhiaTruoc,anhPhiaSau,ngayGioVao,maLoaiXe,maDichVu,maNV,ngayGioRa,tinhTrang) "+
                        $"VALUES(N'{soThe}',"+
                         $"N'{bienSoXe}',"+
                         $"'{Ulti.ImageToByteArray(anhPhiaTruoc)}',"+
                         $"'{ Ulti.ImageToByteArray(anhPhiaSau)}',"+
                         $"'{ngayGioVao.ToString("yyyy - MM - dd hh: mm: ss")}',"+
                         $"N'{maLoaiXe}',"+
                         $"{maDichVu},"+
                          $"{MaNV},"+
                          $"NULL,"+
                          $"0 )";

            //ImageToByteArray(pic);
       
            return data.ExecuteNonQuery(query);
        }

    }
}
