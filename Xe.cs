using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool addXe2(string soThe, string bienSoXe, Image anhPhiaTruoc, Image anhPhiaSau, DateTime ngayGioVao, string maLoaiXe, int maDichVu, int MaNV)
        {
            #region
            //string query = $"INSERT INTO dbo.XeDichVu(soThe,bienSoXe,anhPhiaTruoc,anhPhiaSau,ngayGioVao,maLoaiXe,maDichVu,maNV,ngayGioRa,tinhTrang) "+
            //            $"VALUES(N'{soThe}',"+
            //             $"N'{bienSoXe}',"+
            //             $"'{Ulti.ImageToByteArray(anhPhiaTruoc)}',"+
            //             $"'{ Ulti.ImageToByteArray(anhPhiaSau)}',"+
            //             $"'{ngayGioVao.ToString("yyyy - MM - dd hh: mm: ss")}',"+
            //             $"N'{maLoaiXe}',"+
            //             $"{maDichVu},"+
            //              $"{MaNV},"+
            //              $"NULL,"+
            //              $"0 )";

            //string query = $"INSERT INTO dbo.XeDichVu(soThe,bienSoXe,anhPhiaTruoc,anhPhiaSau,ngayGioVao,maLoaiXe,maDichVu,maNV,ngayGioRa,tinhTrang) " +
            //$"VALUES(N'{soThe}'," +
            // $"N'{bienSoXe}'," +
            //$"@andTruoc," +
            //$"'@anhSau'," +
            // $"'{ngayGioVao.ToString("yyyy - MM - dd hh: mm: ss")}'," +
            // $"N'{maLoaiXe}'," +
            // $"{maDichVu}," +
            //  $"{MaNV}," +
            //  $"NULL," +
            //  $"0 )";

            //ImageToByteArray(pic);

            //     return data.ExecuteNonQuery(query);
            #endregion
            try
            {

                string querySQL = $"INSERT INTO dbo.XeDichVu(soThe,bienSoXe,anhPhiaTruoc,anhPhiaSau,ngayGioVao,maLoaiXe,maDichVu,maNV,ngayGioRa,tinhTrang) " +
                            $"VALUES(N'{soThe}'," +
                             $"N'{bienSoXe}'," +
                            $"@andTruoc," +
                            $"@anhSau," +
                             $"'{ngayGioVao.ToString("yyyy - MM - dd hh: mm: ss")}'," +
                             $"N'{maLoaiXe}'," +
                             $"{maDichVu}," +
                              $"{MaNV}," +
                              $"NULL," +
                              $"0 )";



                SqlCommand command = new SqlCommand(querySQL, data.Connection);




                command.Parameters.Add("@anhSau", SqlDbType.Image).Value = Ulti.ImageToByteArray(anhPhiaSau);
                command.Parameters.Add("@andTruoc", SqlDbType.Image).Value = Ulti.ImageToByteArray(anhPhiaTruoc);
                data.openConnection();

                int ret = command.ExecuteNonQuery();

                if (ret > 0)
                {

                    return true;

                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                data.closeConnection();
            }
            return false;
        }
        public bool addXe(string soThe, string bienSoXe, Image anhPhiaTruoc, Image anhPhiaSau, DateTime ngayGioVao, string maLoaiXe, int maDichVu, int MaNV,string loaiGoi,int phi=0)
        {
            //string querySQL = $"INSERT INTO dbo.XeDichVu(soThe,bienSoXe,anhPhiaTruoc,anhPhiaSau,ngayGioVao,maLoaiXe,maDichVu,maNV,ngayGioRa,tinhTrang) " +
            //            $"VALUES(N'{soThe}'," +
            //             $"N'{bienSoXe}'," +
            //            $"@andTruoc," +
            //            $"@anhSau," +
            //             $"'{ngayGioVao.ToString("yyyy - MM - dd hh: mm: ss")}'," +
            //             $"N'{maLoaiXe}'," +
            //             $"{maDichVu}," +
            //              $"{MaNV}," +
            //              $"NULL," +
            //              $"0 )";

            string querySQL = $"INSERT INTO dbo.XeDichVu(soThe,bienSoXe,anhPhiaTruoc,anhPhiaSau,ngayGioVao,maLoaiXe,maDichVu,maNV,ngayGioRa,tinhTrang,loaiGoi,phi) " +
                        $"VALUES(N'{soThe}'," +
                         $"N'{bienSoXe}'," +
                        $"@andTruoc," +
                        $"@anhSau," +
                         $"'{ngayGioVao.ToString("yyyy - MM - dd hh: mm: ss")}'," +
                         $"N'{maLoaiXe}'," +
                         $"{maDichVu}," +
                          $"{MaNV}," +
                          $"NULL," +
                          $"0 ," +
                          $"N'{loaiGoi}'," +
                          $"{phi})";
            SqlCommand command = new SqlCommand(querySQL, data.Connection);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@anhSau", Ulti.ImageToByteArray(anhPhiaSau)));
            parameters.Add(new SqlParameter("@andTruoc", Ulti.ImageToByteArray(anhPhiaTruoc)));
            return data.ExecuteNonQuery(querySQL, parameters.ToArray());
        }

        public DataTable getDanhSachXeDichVu(string whereCondition="")
        {
            string query = $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,nv.hoTen,x.ngayGioRa,x.tinhTrang,x.phi " +
                $"FROM XeDichVu x " +
                $"JOIN DichVu dv ON dv.maDichVu=x.maDichVu " +
                $"JOIN LoaiXe lx ON lx.maLoaiXe =x.maLoaiXe " +
                $"JOIN NhanVien nv ON nv.maNV=x.maNV " +
                $"{whereCondition}";

            return data.getTable(query);
        }
        public bool updateXedichVu(List<int> ids,List<bool> done)
        {
            string querySQL = "";
            bool result = true;
            for (int i = 0; i < ids.Count; i++)
            {
                int tinhTrang = done[i] ? 1 : 0;
                querySQL = $"UPDATE XeDichVu SET tinhTrang={tinhTrang} WHERE id={ids[i]}";
                if (!data.ExecuteNonQuery(querySQL))
                    result = false;

            }
            

            return result;
        }
        public DataTable timSoXe(string whereCondition = "")
        {
            string query = $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,nv.hoTen,x.ngayGioRa,x.tinhTrang,x.phi " +
                $"FROM XeDichVu x " +
                $"JOIN DichVu dv ON dv.maDichVu=x.maDichVu " +
                $"JOIN LoaiXe lx ON lx.maLoaiXe =x.maLoaiXe " +
                $"JOIN NhanVien nv ON nv.maNV=x.maNV " +
                $"{whereCondition}";
            return data.getTable(query);
        }

        public List<int> getGiaTheoGioCacLoaiXe()
        {
            string query = $"SELECT giaTien FROM BangGia WHERE maDichVu=1";
            DataTable dt= data.getTable(query);
            List<int> giaTienTheoXe = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                giaTienTheoXe.Add((int)dt.Rows[i][0]);
            }
            return giaTienTheoXe;
        }
        public List<int> getGiaSuaXe()
        {
            string query = $"SELECT giaTien FROM BangGia WHERE maDichVu=2";
            DataTable dt = data.getTable(query);
            List<int> giaTienTheoXe = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                giaTienTheoXe.Add((int)dt.Rows[i][0]);
            }
            return giaTienTheoXe;
        }
        public List<int> getGiaRuaXe()
        {
            string query = $"SELECT giaTien FROM BangGia WHERE maDichVu=3";
            DataTable dt = data.getTable(query);
            List<int> giaTienTheoXe = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                giaTienTheoXe.Add((int)dt.Rows[i][0]);
            }
            return giaTienTheoXe;
        }
        public List<int> getTienXe(int maDichVu)
        {
            string query = $"SELECT giaTien FROM BangGia WHERE maDichVu={maDichVu}";
            DataTable dt = data.getTable(query);
            List<int> giaTienTheoXe = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                giaTienTheoXe.Add((int)dt.Rows[i][0]);
            }
            return giaTienTheoXe;
        }

        public DataTable timXeDeChoRa(string soThe)
        {
            string query = $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,x.ngayGioVao,x.ngayGioRa,x.phi,bg.giaTien,dv.tenDichVu " +
              $"FROM XeDichVu x " +
              $"JOIN DichVu dv ON dv.maDichVu=x.maDichVu " +
              $"JOIN LoaiXe lx ON lx.maLoaiXe =x.maLoaiXe " +
              $"JOIN NhanVien nv ON nv.maNV=x.maNV " +
               $"JOIN TheXe tx ON tx.soThe=x.soThe " +
               $"JOIN BangGia bg ON bg.maLoaiXe=x.maLoaiXe AND bg.maDichVu=x.maDichVu " +
             $"WHERE tx.tinhTrang=1 AND x.tinhTrang=1 AND x.soThe=N'{soThe}'";
            //return data.getTable(query);
            //string query = $"SELECT * FROM XeDichVu x " +
            //    $"JOIN TheXe tx ON tx.soThe=x.soThe " +
            //    $"WHERE tx.tinhTrang=1 AND x.tinhTrang=1 AND x.soThe={soThe}";
            // string query = @"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,x.loaiGoi,x.ngayGioRa,x.phi 
            //   FROM XeDichVu x 
            //  JOIN DichVu dv ON dv.maDichVu=x.maDichVu
            //   JOIN LoaiXe lx ON lx.maLoaiXe =x.maLoaiXe 
            // JOIN NhanVien nv ON nv.maNV=x.maNV 
            //   JOIN TheXe tx ON tx.soThe=x.soThe 
            //WHERE tx.tinhTrang=1 AND x.tinhTrang=1 AND x.soThe=N'003'";


            return data.getTable(query);
        }
        public bool updateTheXe(string soThe)
        {
            string querySQL = $"UPDATE dbo.TheXe SET tinhTrang=0 WHERE soThe={soThe}";

            return data.ExecuteNonQuery(querySQL);
        }
        public bool updatePhi(int id,string phi)
        {
            string querySQL = $"UPDATE dbo.XeDichVu SET phi={phi} WHERE id={id}";

            return data.ExecuteNonQuery(querySQL);
        }
        public bool updateGia(int maDichVu,string [] gia)
        {
    
            bool result = true;
            for (int i = 0; i < 3; i++)
            {
                string querySQL = $"UPDATE dbo.BangGia SET giaTien={gia[i]} WHERE maDichVu={maDichVu} AND maLoaiXe=N'LX0{i+1}' ";
                if (!data.ExecuteNonQuery(querySQL))
                    result = false;

            }


            return result;

           
        }

    }
}
