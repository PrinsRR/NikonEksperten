using System.Data.SqlClient;

namespace NikonRepo
{
    public static class Conn
    {
        
        public static SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection("server=194.255.108.50;database=dbnikon_web115_7;uid=nikon_web115_7;pwd=eG8338S3;MultipleActiveResultSets=True");
            return con;
        }

        public static SqlConnection CreateConnection()
        {
            var cn = GetCon();
            cn.Open();
            return cn;
        }
    }
}
