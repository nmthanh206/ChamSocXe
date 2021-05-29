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
        public bool addXe(string soThe, string bienSoXe, Image anhPhiaTruoc, Image anhPhiaSau, DateTime ngayGioVao, string maLoaiXe, int maDichVu, int MaNV)
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
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@anhSau", Ulti.ImageToByteArray(anhPhiaSau)));
            parameters.Add(new SqlParameter("@andTruoc", Ulti.ImageToByteArray(anhPhiaTruoc)));
            return data.ExecuteNonQuery(querySQL, parameters.ToArray());
        }

        public DataTable getDanhSachXeDichVu(string whereCondition="")
        {
            string query = $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,nv.hoTen,x.ngayGioRa,x.tinhTrang,x.phi " +
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
            string query = $"SELECT x.id,x.bienSoXe,x.anhPhiaTruoc,x.anhPhiaSau,lx.tenLoaiXe,dv.tenDichVu,nv.hoTen,x.ngayGioRa,x.tinhTrang,x.phi " +
                $"FROM XeDichVu x " +
                $"JOIN DichVu dv ON dv.maDichVu=x.maDichVu " +
                $"JOIN LoaiXe lx ON lx.maLoaiXe =x.maLoaiXe " +
                $"JOIN NhanVien nv ON nv.maNV=x.maNV " +
                $"{whereCondition}";
            return data.getTable(query);
        }

    }
}
