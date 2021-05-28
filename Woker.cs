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

        public DataTable getFullWorkersByRole(int maCM)
        {
            string query = $"SELECT nv.maNV,nv.hoTen,nv.ngaySinh,nv.gioiTinh,nv.diaChi,nv.sdt,nv.email,cm.tenCM FROM NhanVien nv " +
                            $"JOIN ChuyenMon cm ON cm.maCM=nv.MaCM " +
                            $"WHERE nv.maCM={maCM}";
            return data.getTable(query);
        }
    }
}
