using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionresto
{
    class ClasseCat

    {
        private SqlConnection con; 
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter da;
        private string cnxstring ;
        public ClasseCat(){
         cnxstring = @"Data Source=(LocalDB)\MSSQLLocalDB;
        Initial Catalog=Gestionresto;Integrated Security=True";
            con = new SqlConnection(cnxstring);
            cmd = new SqlCommand();
            cmd.Connection = con;


    }
       

        
        public DataTable Recupdonne(string req)
        {   dt=new DataTable();
            da = new SqlDataAdapter(req,cnxstring);
            da.Fill(dt);
            return dt;
        }
        public int envoidonne(string req)
        {
            int cnt=0;
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText=req;
            cnt=cmd.ExecuteNonQuery();
            return cnt;
        }

        /*public static bool Valid(string User, string pass)
        {
            bool isValid = false;
            string cc = @"Select * from Users where username='" + User + "' and upass='" + pass + "'";
            SqlCommand cmd = new SqlCommand(cc);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                isValid = true;
            }
            return isValid;
        }*/



    }
}
