using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public DataTable getTable(string query)
        {
       
            DataTable datatable = new DataTable();
            try
            {              
                SqlCommand cmd = new SqlCommand(query, Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                openConnection();
                adapter.Fill(datatable);

            }
            catch (Exception error)
            {
                MessageBox.Show($"{error.Message}Loi nhan data");
            }
            finally
            {
                closeConnection();
            }
            return datatable;

        }
    }
}
