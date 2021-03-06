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

        public bool ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {

           
            try
            {
                SqlCommand cmd = new SqlCommand(query, Connection);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                openConnection();
                int ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    //MessageBox.Show("Them thanh cong", "Thong bao", MessageBoxButtons.OK);
                    return true;
                }
                else
                {
                    //MessageBox.Show("Them that bai", "Thong bao", MessageBoxButtons.OK);
                    return false;
                }                    
                   
            }
            catch (Exception error)
            {
             
                MessageBox.Show($"{error.Message}Loi nhan data");
            }
            finally
            {
                closeConnection();
            }
            return false;

        }
    }
}
