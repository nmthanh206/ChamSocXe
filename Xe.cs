using System;
using System.Collections.Generic;
using System.Data;
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

    }
}
