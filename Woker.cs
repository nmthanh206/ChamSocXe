using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamSocXe
{
    class Woker
    {
        MyDatabase data = new MyDatabase();
        public DataTable getFullWorkers()
        {
            string query = $"SELECT nv.maNV,nv.hoTen,nv.ngaySinh,nv.gioiTinh,nv.diaChi,nv.sdt,nv.email,cm.tenCM FROM NhanVien nv " +
                            $"JOIN ChuyenMon cm ON cm.maCM=nv.MaCM";
            return data.getTable(query);
        }
        public DataTable getChuyenMon()
        {
            string query = $"SELECT * FROM ChuyenMon";
            return data.getTable(query);
        }
        public bool addCM( int maCM, string tenCM)
        {
            string query = $"INSERT INTO ChuyenMon (maCM,tenCM) " +
                $"VALUES ({maCM},N'{tenCM}')";
            return data.ExecuteNonQuery(query);
        }
        public bool removeCM(int maCM)
        {
            string query = $"DELETE FROM ChuyenMon WHERE maCM={maCM}";
               
            return data.ExecuteNonQuery(query);
        }
        public bool updateCM(int maCM, string tenCM)
        {
            string query = $"UPDATE ChuyenMon SET tenCM=N'{tenCM}' WHERE maCM={maCM}";
               
            return data.ExecuteNonQuery(query);
        }
        public DataTable getFullWorkersByRole(int maCM, string value="", int condition=0)
        {
            string whereCondition = "";
            if(condition!=0)
             whereCondition = condition == 1 ? $" AND nv.maNV={value}" : $" AND nv.hoTen LIKE '%" + value + "%' ";
            
            string query = $"SELECT nv.maNV,nv.hoTen,nv.ngaySinh,nv.gioiTinh,nv.diaChi,nv.sdt,nv.email,cm.tenCM FROM NhanVien nv " +
                            $"JOIN ChuyenMon cm ON cm.maCM=nv.MaCM " +
                            $"WHERE nv.maCM={maCM} {whereCondition}";
            return data.getTable(query);
        }

        public bool addWorker(int maNV, int maCM, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email)
        {
            string query = $"INSERT INTO NhanVien (maNV,maCM,matKhau,hoTen,ngaySinh,gioiTinh,diaChi,sdt,email) " +
                $"VALUES ({maNV},{maCM},'{maNV}','{hoTen}','{ngaySinh.ToString("yyyy-MM-dd")}',N'{gioiTinh}','{diaChi}','{sdt}','{email}')";
            return data.ExecuteNonQuery(query);
        }
        public bool removeWorker(int maNV)
        {
            string query = $"DELETE FROM NhanVien WHERE maNV={maNV}";
            return data.ExecuteNonQuery(query);
        }
        public bool updateWorker(int maNV, int maCM, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, string email)
        {
            string query = $"UPDATE NhanVien SET " +
                           $"maCM={maCM},matKhau='{maNV}',hoTen='{hoTen}',ngaySinh='{ngaySinh.ToString("yyyy-MM-dd")}',gioiTinh=N'{gioiTinh}',diaChi='{diaChi}',sdt='{sdt}',email='{email}' " +
                           $"WHERE maNV={maNV}";
            return data.ExecuteNonQuery(query);
        }

        public DataTable FindWorkerByIdOrName(string value, int condition)
        {
            string whereCondition = condition == 1 ? $"WHERE nv.maNV={value}" : $"WHERE nv.hoTen LIKE '%" + value + "%' ";
            string query = $"SELECT nv.maNV,nv.hoTen,nv.ngaySinh,nv.gioiTinh,nv.diaChi,nv.sdt,nv.email,cm.tenCM FROM NhanVien nv " +
                           $"JOIN ChuyenMon cm ON cm.maCM=nv.MaCM " +
                           $"{whereCondition}";
            return data.getTable(query);
        }
    }
}
