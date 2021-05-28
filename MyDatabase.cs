using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamSocXe
{
    class MyDatabase
    {
        private string strConection = @"Data Source=desktop-cspcfnb\sqlexpress;Initial Catalog=ChamSocXe;Integrated Security=True";
        private SqlConnection connection;
        public SqlConnection Connection { get => connection; }
        public MyDatabase()
        {
            connection = new SqlConnection(strConection);
        }

        public void openConnection()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }
        public void closeConnection()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

    }
}
